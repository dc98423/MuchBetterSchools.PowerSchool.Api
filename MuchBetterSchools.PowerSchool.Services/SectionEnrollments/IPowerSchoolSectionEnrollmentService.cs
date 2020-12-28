using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using MuchBetterSchools.PowerSchool.Services.Sections;

namespace MuchBetterSchools.PowerSchool.Services.SectionEnrollments
{
    public interface IPowerSchoolSectionEnrollmentService
    {
        //This will take a section number and get the enrollments
        // the graph will cache section number and its enrollments

        public Task<IEnumerable<PowerSchoolSectionEnrollment>> GetSectionEnrollments(PowerSchoolSection section, CancellationToken token);
    }
}