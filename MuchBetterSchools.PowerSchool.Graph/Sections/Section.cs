namespace MuchBetterSchools.PowerSchool.Graph.Sections
{
    public class Section
    {
        public string Id { get; set; } = null!;
        public string SchoolId { get; set; } = null!;
        public string CourseId { get; set; } = null!;
        public string TermId { get; set; } = null!;
        public string SectionNumber { get; set; } = null!;
        public string Expression { get; set; } = null!;
        public string? StaffId { get; set; }
    }
}