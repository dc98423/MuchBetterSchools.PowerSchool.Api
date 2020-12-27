using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using MuchBetterSchools.PowerSchool.Graph.Courses;
using MuchBetterSchools.PowerSchool.Graph.Enrollments;
using MuchBetterSchools.PowerSchool.Graph.Schools;
using MuchBetterSchools.PowerSchool.Graph.SectionEnrollments;
using MuchBetterSchools.PowerSchool.Graph.Sections;
using MuchBetterSchools.PowerSchool.Services.Course;
using MuchBetterSchools.PowerSchool.Services.Enrollments;
using MuchBetterSchools.PowerSchool.Services.Schools;
using MuchBetterSchools.PowerSchool.Services.SectionEnrollments;
using MuchBetterSchools.PowerSchool.Services.Sections;

namespace MuchBetterSchools.PowerSchool.Graph.Students
{
    public sealed class StudentResolvers
    {
        public async Task<IEnumerable<Course>> GetCourses(
            [Parent] Student student,
            [Service] IPowerSchoolCourseService powerSchoolCourseService,
            IResolverContext context)
        {
            var loader = context.CacheDataLoader<string, IEnumerable<PowerSchoolCourse>>(
                powerSchoolCourseService.GetAllForStudent,
                cacheSize: 10000);

            var foundCourses = await loader.LoadAsync(
                student.StudentNumber,
                new CancellationToken());
            
            return foundCourses.ToGraphTypes();
        }

        public async Task<Enrollment> GetCurrentEnrollment(
            [Parent] Student student,
            [Service] IPowerSchoolEnrollmentService powerSchoolEnrollmentService,
            IResolverContext context)
        {
            var loader = context.CacheDataLoader<string, PowerSchoolEnrollment>(
                powerSchoolEnrollmentService.GetCurrentEnrollmentForStudent,
                cacheSize: 10000);

            var foundEnrollment = await loader.LoadAsync(student.StudentNumber,
                new CancellationToken());

            return foundEnrollment.ToGraphType();
        }

        public async Task<School> GetCurrentSchool(
            [Parent] Student student,
            [Service] IPowerSchoolSchoolService powerSchoolSchoolService,
            IResolverContext context)
        {
            var loader = context.CacheDataLoader<string, PowerSchoolSchool>(
                powerSchoolSchoolService.GetCurrentSchoolForStudent,
                cacheSize: 10000);

            var foundSchool = await loader.LoadAsync(student.StudentNumber,
                new CancellationToken());

            return foundSchool.ToGraphType();
        }

        public async Task<IEnumerable<SectionEnrollment>> GetCurrentSectionEnrollments(
            [Parent] Student student,
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
            
            //ToDo: Determine if we need to add a year to this

            var currentSchoolYearDate = DateTime.Parse(student.CurrentEnrollment.EntryDate ?? throw new InvalidOperationException());

            var foundSections = await sectionLoader.LoadAsync(
                (student.CurrentSchool.Id, currentSchoolYearDate.Year.ToString()),
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

            var studentEnrollments = allEnrollments.Where(x => x.StudentId.ToString().Equals(student.Id));

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
    }
}