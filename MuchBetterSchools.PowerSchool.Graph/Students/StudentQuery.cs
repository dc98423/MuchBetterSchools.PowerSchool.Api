using System.Threading.Tasks;
using MuchBetterSchools.PowerSchool.Services.Students;

namespace MuchBetterSchools.PowerSchool.Graph.Students
{
    public sealed class StudentQuery
    {
        private readonly IPowerSchoolStudentService _powerSchoolStudentService;

        public StudentQuery(IPowerSchoolStudentService powerSchoolStudentService)
        {
            _powerSchoolStudentService = powerSchoolStudentService;
        }

        public async Task<Student> byStudentNumber(string studentNumber)
        {
            var found = await this._powerSchoolStudentService.Get(studentNumber);
            return found.ToGraphType();
        }
    }
}