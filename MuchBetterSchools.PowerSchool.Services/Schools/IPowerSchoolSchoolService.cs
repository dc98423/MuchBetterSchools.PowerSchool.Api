using System.Threading;
using System.Threading.Tasks;

namespace MuchBetterSchools.PowerSchool.Services.Schools
{
    public interface IPowerSchoolSchoolService
    {
        public Task<PowerSchoolSchool> GetCurrentSchoolForStudent(string studentNumber, CancellationToken token);
    }
}