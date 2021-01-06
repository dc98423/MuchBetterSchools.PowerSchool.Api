using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MuchBetterSchools.PowerSchool.Services.Enrollments
{
    public sealed class PowerSchoolEnrollmentService : IPowerSchoolEnrollmentService
    {
        public async Task<PowerSchoolEnrollment> GetCurrentEnrollmentForStudent(string studentNumber, CancellationToken cancellationToken)
        {
            return await Task.FromResult(MockEnrollment());
        }

        public async Task<IEnumerable<PowerSchoolEnrollment>> GetEnrollmentsBySchool(string schoolId)
        {
            var result = new List<PowerSchoolEnrollment>();

            for (int i = 0; i < 100; i++)
            {
                result.Add(MockEnrollment(schoolId: schoolId));
            }

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<PowerSchoolEnrollment>> GetAll()
        {
            var result = new List<PowerSchoolEnrollment>();

            for (int i = 0; i < 1000; i++)
            {
                result.Add(MockEnrollment());
            }

            return await Task.FromResult(result);
        }

        private PowerSchoolEnrollment MockEnrollment(string schoolId = null)
        {
            return new PowerSchoolEnrollment(
                new Random().Next(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                DateTime.Now,
                schoolId ?? Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString());
        }
    }
}