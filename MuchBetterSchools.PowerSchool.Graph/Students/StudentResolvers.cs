using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using MuchBetterSchools.PowerSchool.Graph.Enrollments;
using MuchBetterSchools.PowerSchool.Graph.Schools;
using MuchBetterSchools.PowerSchool.Services.Enrollments;
using MuchBetterSchools.PowerSchool.Services.Schools;

namespace MuchBetterSchools.PowerSchool.Graph.Students
{
    public sealed class StudentResolvers
    {
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