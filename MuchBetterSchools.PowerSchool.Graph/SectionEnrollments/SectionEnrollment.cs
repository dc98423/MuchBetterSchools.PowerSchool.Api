using MuchBetterSchools.PowerSchool.Graph.Sections;

namespace MuchBetterSchools.PowerSchool.Graph.SectionEnrollments
{
    public class SectionEnrollment
    {
        public Section Section { get; set; } = null!;
        
        public string StudentId { get; set; } = null!;
        
        public string EntryDate { get; set; } = null!;

        public string? ExitDate { get; set; }
        
        public string? Dropped { get; set; }
    }
}