using MuchBetterSchools.PowerSchool.Graph.Enrollments;
using MuchBetterSchools.PowerSchool.Graph.Students;
using MuchBetterSchools.PowerSchool.Services.Enrollments;
using MuchBetterSchools.PowerSchool.Services.Students;

namespace MuchBetterSchools.PowerSchool.Graph
{
    public sealed class Query
    {
        private readonly IPowerSchoolStudentService _powerSchoolStudentService;
        private readonly IPowerSchoolEnrollmentService _powerSchoolEnrollmentService;

        public Query(
            IPowerSchoolStudentService powerSchoolStudentService,
            IPowerSchoolEnrollmentService powerSchoolEnrollmentService)
        {
            _powerSchoolStudentService = powerSchoolStudentService;
            _powerSchoolEnrollmentService = powerSchoolEnrollmentService;
        }

        public StudentQuery Student() => new StudentQuery(_powerSchoolStudentService);

        public EnrollmentQuery Enrollment() => new EnrollmentQuery(_powerSchoolEnrollmentService);
    }
}