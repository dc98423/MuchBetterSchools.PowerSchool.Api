using MuchBetterSchools.PowerSchool.Graph.Enrollments;
using MuchBetterSchools.PowerSchool.Graph.Sections;
using MuchBetterSchools.PowerSchool.Graph.Students;
using MuchBetterSchools.PowerSchool.Services.Enrollments;
using MuchBetterSchools.PowerSchool.Services.Sections;
using MuchBetterSchools.PowerSchool.Services.Students;

namespace MuchBetterSchools.PowerSchool.Graph
{
    public sealed class Query
    {
        private readonly IPowerSchoolStudentService _powerSchoolStudentService;
        private readonly IPowerSchoolEnrollmentService _powerSchoolEnrollmentService;
        private readonly IPowerSchoolSectionService _powerSchoolSectionService;

        public Query(
            IPowerSchoolStudentService powerSchoolStudentService,
            IPowerSchoolEnrollmentService powerSchoolEnrollmentService,
            IPowerSchoolSectionService powerSchoolSectionService)
        {
            _powerSchoolStudentService = powerSchoolStudentService;
            _powerSchoolEnrollmentService = powerSchoolEnrollmentService;
            _powerSchoolSectionService = powerSchoolSectionService;
        }

        public StudentQuery Student() => new StudentQuery(_powerSchoolStudentService);

        public EnrollmentQuery Enrollment() => new EnrollmentQuery(_powerSchoolEnrollmentService);

        public SectionQuery Section => new SectionQuery(_powerSchoolSectionService);
    }
}