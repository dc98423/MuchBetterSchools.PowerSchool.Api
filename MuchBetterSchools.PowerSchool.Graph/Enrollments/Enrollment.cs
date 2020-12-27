namespace MuchBetterSchools.PowerSchool.Graph.Enrollments
{
    public class Enrollment
    {
        public string GradeLevel { get; set; }
        
        public string EntryCode { get; set; }

        public string EntryDate { get; set; }

        public string? ExitCode { get; set; }
        
        public string? ExitDate { get; set; }

        public string SchoolId { get; set; }

        public string DistrictOfResidence { get; set; }

        public string Track { get; set; }
    }
}