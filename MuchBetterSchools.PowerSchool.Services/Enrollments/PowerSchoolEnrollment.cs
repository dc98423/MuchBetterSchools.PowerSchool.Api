using System;

namespace MuchBetterSchools.PowerSchool.Services.Enrollments
{
    public sealed class PowerSchoolEnrollment
    {
        public PowerSchoolEnrollment(
            int studentId,
            string gradeLevel,
            string entryCode,
            DateTime entryDate,
            string schoolId,
            string districtOfResidence,
            string track,
            string? exitCode = null,
            DateTime? exitDate = null)
        {
            StudentId = studentId;
            GradeLevel = gradeLevel;
            EntryCode = entryCode;
            EntryDate = entryDate;
            SchoolId = schoolId;
            DistrictOfResidence = districtOfResidence;
            Track = track;
            ExitCode = exitCode;
            ExitDate = exitDate;
        }

        public int StudentId { get; }
        public string GradeLevel { get; }
        
        public string EntryCode { get; }

        public DateTime EntryDate { get; }

        public string? ExitCode { get; }
        
        public DateTime? ExitDate { get; }

        public string SchoolId { get; }

        public string DistrictOfResidence { get; }

        public string Track { get; }
    }
}