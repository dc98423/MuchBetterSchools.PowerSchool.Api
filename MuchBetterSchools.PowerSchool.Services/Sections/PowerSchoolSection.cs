namespace MuchBetterSchools.PowerSchool.Services.Sections
{
    public sealed class PowerSchoolSection
    {
        public PowerSchoolSection(
            int id,
            string schoolId,
            string courseId,
            string termId,
            string sectionNumber,
            string expression,
            string staffId)
        {
            Id = id;
            SchoolId = schoolId;
            CourseId = courseId;
            TermId = termId;
            SectionNumber = sectionNumber;
            Expression = expression;
            StaffId = staffId;
        }
        
        public int Id { get; }
        public string SchoolId { get; }
        public string CourseId { get; }
        public string TermId { get; }
        public string SectionNumber { get; }
        public string Expression { get; }
        public string StaffId { get; }
    }
}