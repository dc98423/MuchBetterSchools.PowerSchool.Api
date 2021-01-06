using System.Collections.Generic;
using System.Threading.Tasks;
using MuchBetterSchools.PowerSchool.Services.Enrollments;

namespace MuchBetterSchools.PowerSchool.Graph.Enrollments
{
    public sealed class EnrollmentQuery
    {
        private readonly IPowerSchoolEnrollmentService _powerSchoolEnrollmentService;

        public EnrollmentQuery(IPowerSchoolEnrollmentService powerSchoolEnrollmentService)
        {
            _powerSchoolEnrollmentService = powerSchoolEnrollmentService;
        }

        public async Task<IEnumerable<Enrollment>> Select(string schoolId)
        {
            var found = await this._powerSchoolEnrollmentService
                .GetEnrollmentsBySchool(schoolId);

            return found.ToGraphType();
        }

        public async Task<IEnumerable<Enrollment>> SelectAll()
        {
            var found = await this._powerSchoolEnrollmentService.GetAll();

            return found.ToGraphType();
        }
    }
}