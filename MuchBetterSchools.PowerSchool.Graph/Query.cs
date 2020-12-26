using MuchBetterSchools.PowerSchool.Graph.Students;
using MuchBetterSchools.PowerSchool.Services.Students;

namespace MuchBetterSchools.PowerSchool.Graph
{
    public class Query
    {
        private readonly IPowerSchoolStudentService _powerSchoolStudentService;

        public Query(IPowerSchoolStudentService powerSchoolStudentService)
        {
            _powerSchoolStudentService = powerSchoolStudentService;
        }

        public StudentQuery Student() => new StudentQuery(_powerSchoolStudentService);
    }
}