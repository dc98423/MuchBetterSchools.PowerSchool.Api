using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MuchBetterSchools.PowerSchool.Services.Schools;

namespace MuchBetterSchools.PowerSchool.Services.Sections
{
    public interface IPowerSchoolSectionService
    {
        public Task<IEnumerable<PowerSchoolSection>>GetAllBySchoolAndYear((string, string) schoolAndFourDigitYear, CancellationToken token);
    }
}