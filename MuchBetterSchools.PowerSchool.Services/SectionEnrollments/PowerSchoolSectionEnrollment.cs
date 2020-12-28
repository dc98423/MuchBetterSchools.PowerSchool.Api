using System;
using MuchBetterSchools.PowerSchool.Services.Sections;

namespace MuchBetterSchools.PowerSchool.Services.SectionEnrollments
{
    public sealed class PowerSchoolSectionEnrollment
    {
        public PowerSchoolSectionEnrollment(
            PowerSchoolSection powerSchoolSection,
            int studentId,
            DateTime entryDate,
            DateTime exitDate,
            bool dropped)
        {
            PowerSchoolSection = powerSchoolSection;
            StudentId = studentId;
            EntryDate = entryDate;
            ExitDate = exitDate;
            Dropped = dropped;
        }
        
        public PowerSchoolSection PowerSchoolSection { get; }

        public int StudentId { get; set; }

        public DateTime EntryDate { get; }

        public DateTime ExitDate { get; }
        
        public bool Dropped { get; }
    }
}