using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MuchBetterSchools.PowerSchool.Services.Course
{
    public interface IPowerSchoolCourseService
    {
        public Task<IEnumerable<PowerSchoolCourse>> GetAll();

        public Task<IEnumerable<PowerSchoolCourse>> GetAllForStudent(string studentNumber, CancellationToken token);
    }
}