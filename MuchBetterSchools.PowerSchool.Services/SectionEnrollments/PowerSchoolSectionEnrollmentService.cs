using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MuchBetterSchools.PowerSchool.Services.Sections;

namespace MuchBetterSchools.PowerSchool.Services.SectionEnrollments
{
    public sealed class PowerSchoolSectionEnrollmentService : IPowerSchoolSectionEnrollmentService
    {
        public async Task<IEnumerable<PowerSchoolSectionEnrollment>> GetSectionEnrollments(PowerSchoolSection section, CancellationToken token)
        {
            return await Task.FromResult(new List<PowerSchoolSectionEnrollment>()
            {
                MockSectionEnrollment(section),
                MockSectionEnrollment(section),
                MockSectionEnrollment(section)
            });
        }

        private PowerSchoolSectionEnrollment MockSectionEnrollment(PowerSchoolSection section)
        {
            return new PowerSchoolSectionEnrollment(
                section,
                new Random().Next(),
                DateTime.Now,
                DateTime.Now,
                true);
        }
    }
}