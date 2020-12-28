using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuchBetterSchools.PowerSchool.Services.Students
{
    public interface IPowerSchoolStudentService
    {
        public Task<IEnumerable<PowerSchoolStudent>> GetAll();

        public Task<IEnumerable<PowerSchoolStudent>> GetAll(string schoolId);

        public Task<PowerSchoolStudent> Get(string studentNumber);
    }
}