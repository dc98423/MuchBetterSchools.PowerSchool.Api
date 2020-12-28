using System;
using System.Threading;
using System.Threading.Tasks;

namespace MuchBetterSchools.PowerSchool.Services.Schools
{
    public sealed class PowerSchoolSchoolService : IPowerSchoolSchoolService
    {
        public async Task<PowerSchoolSchool> GetCurrentSchoolForStudent(string studentNumber, CancellationToken token)
        {
            return await Task.FromResult(new PowerSchoolSchool(
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()));
        }
    }
}