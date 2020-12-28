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
    }
}