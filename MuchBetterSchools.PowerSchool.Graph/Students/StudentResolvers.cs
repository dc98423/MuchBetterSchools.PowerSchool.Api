using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using MuchBetterSchools.PowerSchool.Graph.Courses;
using MuchBetterSchools.PowerSchool.Services.Course;

namespace MuchBetterSchools.PowerSchool.Graph.Students
{
    public class StudentResolvers
    {
        public async Task<IEnumerable<Course>> GetCourses(
            [Parent] Student student,
            [Service] IPowerSchoolCourseService powerSchoolCourseService,
            IResolverContext context )
        {
            var loader = context.CacheDataLoader<string, IEnumerable<PowerSchoolCourse>>(
                powerSchoolCourseService.GetAllForStudent,
                cacheSize: 10000);

            var foundCourses = await loader.LoadAsync(
                student.StudentNumber,
                new CancellationToken());
            
            return foundCourses.ToGraphTypes();
        }
    }
}