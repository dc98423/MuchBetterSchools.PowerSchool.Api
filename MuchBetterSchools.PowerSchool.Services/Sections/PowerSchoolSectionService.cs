using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MuchBetterSchools.PowerSchool.Services.Sections
{
    public class PowerSchoolSectionService : IPowerSchoolSectionService
    {
        public async Task<IEnumerable<PowerSchoolSection>> GetAllBySchoolAndYear((string,string) schoolAndYear, CancellationToken token)
        {
            // When implemented. Get the count first. Set up pagination. Determin number of batchs to reduce concurrent calls
            // to acceptable. Send batches and compile result to return. The graph will be responsible for caching the results.

            return await Task.FromResult(new List<PowerSchoolSection>()
            {
                MockSection(schoolAndYear),
                MockSection(schoolAndYear),
                MockSection(schoolAndYear)
            });
        }

        public async Task<PowerSchoolSection> Get(string sectionNumber)
        {
            return await Task.FromResult(MockSection(sectionNumber));
        }

        public async Task<IEnumerable<PowerSchoolSection>> GetForSchool(string schoolId)
        {
            return await Task.FromResult(new List<PowerSchoolSection>()
            {
                MockSection(schoolId: schoolId),
                MockSection(schoolId: schoolId),
                MockSection(schoolId: schoolId)
            });
        }

        private PowerSchoolSection MockSection((string,string) schoolAndYear)
        {
            return new PowerSchoolSection(
                new Random().Next(),
                schoolAndYear.Item1,
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString());
        }
        
        private PowerSchoolSection MockSection(
            string sectionNumber = null,
            string schoolId = null)
        {
            return new PowerSchoolSection(
                new Random().Next(),
                schoolId ?? Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                sectionNumber ?? Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString());
        }
    }
}