using System;
using System.Threading;
using System.Threading.Tasks;

namespace MuchBetterSchools.PowerSchool.Services.Enrollments
{
    public sealed class PowerSchoolEnrollmentService : IPowerSchoolEnrollmentService
    {
        public async Task<PowerSchoolEnrollment> GetCurrentEnrollmentForStudent(string studentNumber, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new PowerSchoolEnrollment(
                new Random().Next(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                DateTime.Now,
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()));
        }
    }
}