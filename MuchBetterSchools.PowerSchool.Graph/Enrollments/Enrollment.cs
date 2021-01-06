using System.Collections;
using System.Collections.Generic;
using MuchBetterSchools.PowerSchool.Graph.Courses;
using MuchBetterSchools.PowerSchool.Graph.SectionEnrollments;

namespace MuchBetterSchools.PowerSchool.Graph.Enrollments
{
    public class Enrollment
    {

        public string StudentId { get; set; } = null!;
        public string GradeLevel { get; set; } = null!;
        
        public string EntryCode { get; set; } = null!;

        public string EntryDate { get; set; } = null!;

        public string? ExitCode { get; set; } 
        
        public string? ExitDate { get; set; }

        public string SchoolId { get; set; } = null!;

        public string DistrictOfResidence { get; set; } = null!;

        public string? Track { get; set; }
    }
}