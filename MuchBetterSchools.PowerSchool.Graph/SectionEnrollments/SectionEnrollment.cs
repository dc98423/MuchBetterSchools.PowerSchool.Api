using MuchBetterSchools.PowerSchool.Graph.Sections;

namespace MuchBetterSchools.PowerSchool.Graph.SectionEnrollments
{
    public class SectionEnrollment
    {
        public Section Section { get; set; }
        
        public string StudentId { get; set; }
        
        public string EntryDate { get; set; }

        public string ExitDate { get; set; }
        
        public string Dropped { get; set; }
    }
}