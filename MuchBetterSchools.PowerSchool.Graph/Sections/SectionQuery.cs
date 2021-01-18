using System.Collections.Generic;
using System.Threading.Tasks;
using MuchBetterSchools.PowerSchool.Services.Sections;

namespace MuchBetterSchools.PowerSchool.Graph.Sections
{
    public sealed class SectionQuery
    {
        private readonly IPowerSchoolSectionService _powerSchoolSectionService;

        public SectionQuery(IPowerSchoolSectionService powerSchoolSectionService)
        {
            _powerSchoolSectionService = powerSchoolSectionService;
        }

        public async Task<Section> Select(string sectionNumber)
        {
            var found = await this._powerSchoolSectionService.Get(sectionNumber);
            return found.ToGraphType();
        }

        public async Task<IEnumerable<Section>> SelectForSchool(string schoolId)
        {
            var found = await this._powerSchoolSectionService.GetForSchool(schoolId);

            return found.ToGraphType();
        }
    }
}