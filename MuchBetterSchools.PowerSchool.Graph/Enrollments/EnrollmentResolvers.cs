using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using MuchBetterSchools.PowerSchool.Graph.SectionEnrollments;
using MuchBetterSchools.PowerSchool.Graph.Students;
using MuchBetterSchools.PowerSchool.Services.SectionEnrollments;
using MuchBetterSchools.PowerSchool.Services.Sections;
using MuchBetterSchools.PowerSchool.Services.Students;

namespace MuchBetterSchools.PowerSchool.Graph.Enrollments
{
    public sealed class EnrollmentResolvers
    {
        public async Task<IEnumerable<SectionEnrollment>> GetSectionEnrollments(
            [Parent] Enrollment thisEnrollment,
            [Service] IPowerSchoolSectionService powerSchoolSectionService,
            [Service] IPowerSchoolSectionEnrollmentService powerSchoolSectionEnrollmentService,
            IResolverContext context)
        {
            var allEnrollments = new List<PowerSchoolSectionEnrollment>();
            
            var sectionLoader = context.CacheDataLoader<(string, string), IEnumerable<PowerSchoolSection>>(
                powerSchoolSectionService.GetAllBySchoolAndYear,
                cacheSize: 100000);
            
            var enrollmentLoader = context.CacheDataLoader<PowerSchoolSection, IEnumerable<PowerSchoolSectionEnrollment>>(
                powerSchoolSectionEnrollmentService.GetSectionEnrollments,
                cacheSize: 1000000);


            var currentSchoolYearDate = DateTime.Parse(thisEnrollment.EntryDate ?? throw new InvalidOperationException());

            var foundSections = await sectionLoader.LoadAsync(
                (thisEnrollment.SchoolId, currentSchoolYearDate.Year.ToString()),
                new CancellationToken());

            var powerSchoolSections = foundSections as PowerSchoolSection[] ?? foundSections.ToArray();

            var tasks = new List<Task<IEnumerable<PowerSchoolSectionEnrollment>>>();
            
            foreach (var powerSchoolSection in powerSchoolSections)
            {
                var task = enrollmentLoader.LoadAsync(powerSchoolSection, new CancellationToken(false));
                tasks.Add(task);

                if (tasks.Count() >= 30)
                {
                    var batch = await _resolveBatch(tasks);
                    allEnrollments.AddRange(batch);
                }
            }
            
            if (tasks.Any())
            {
                var batch = await _resolveBatch(tasks);
                allEnrollments.AddRange(batch);
            }
            
            //ToDo: Remove This after the service is implemented
#if !DEBUG
            var studentEnrollments = allEnrollments.Where(x => x.StudentId.ToString().Equals(thisEnrollment.StudentId));
            
#else
            var studentEnrollments = allEnrollments;     
#endif

            return studentEnrollments.ToGraphType();

            async Task<List<PowerSchoolSectionEnrollment>> _resolveBatch(List<Task<IEnumerable<PowerSchoolSectionEnrollment>>> tasks)
            {
                var result = new List<PowerSchoolSectionEnrollment>();
                var batch = await Task.WhenAll(tasks);
                foreach (var enrollments in batch)
                {
                    foreach (var enrollment in enrollments)
                    {
                        result.Add(enrollment);
                    }
                }

                return result;
            }
        }

        public async Task<Student> GetStudent(
            [Parent] Enrollment thisEnrollment,
            [Service] IPowerSchoolStudentService studentService,
            IResolverContext context)
        {
            var found = await studentService.Get(thisEnrollment.StudentId);
            return found.ToGraphType();
        }
    }
}