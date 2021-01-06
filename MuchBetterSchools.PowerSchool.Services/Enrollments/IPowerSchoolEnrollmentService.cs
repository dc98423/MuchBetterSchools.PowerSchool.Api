using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MuchBetterSchools.PowerSchool.Services.Enrollments
{
    public interface IPowerSchoolEnrollmentService
    {
        public Task<PowerSchoolEnrollment> GetCurrentEnrollmentForStudent(string studentNumber, CancellationToken cancellationToken);

        public Task<IEnumerable<PowerSchoolEnrollment>> GetEnrollmentsBySchool(string schoolId);

        public Task<IEnumerable<PowerSchoolEnrollment>> GetAll();

    }
}