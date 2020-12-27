using System.Collections;
using System.Collections.Generic;
using MuchBetterSchools.PowerSchool.Graph.Courses;
using MuchBetterSchools.PowerSchool.Graph.Enrollments;
using MuchBetterSchools.PowerSchool.Graph.Schools;
using MuchBetterSchools.PowerSchool.Graph.SectionEnrollments;
using MuchBetterSchools.PowerSchool.Graph.Sections;
using MuchBetterSchools.PowerSchool.Graph.Students;
using MuchBetterSchools.PowerSchool.Services.Course;
using MuchBetterSchools.PowerSchool.Services.Enrollments;
using MuchBetterSchools.PowerSchool.Services.Schools;
using MuchBetterSchools.PowerSchool.Services.SectionEnrollments;
using MuchBetterSchools.PowerSchool.Services.Sections;
using MuchBetterSchools.PowerSchool.Services.Students;

namespace MuchBetterSchools.PowerSchool.Graph
{
    public static class Extensions
    {
        public static Course ToGraphType(this PowerSchoolCourse powerSchoolCourse)
        {
            return new Course()
            {
                Name = powerSchoolCourse.Name
            };
        }

        public static IEnumerable<Course> ToGraphTypes(this IEnumerable<PowerSchoolCourse> powerSchoolCourses)
        {
            var result = new List<Course>();
            
            foreach (var powerSchoolCourse in powerSchoolCourses)
            {
                result.Add(powerSchoolCourse.ToGraphType());
            }

            return result;
        }

        public static Student ToGraphType(this PowerSchoolStudent powerSchoolStudent)
        {
            return new Student()
            {
                FirstName = powerSchoolStudent.FirstName,
                StudentNumber = powerSchoolStudent.StudentNumber
            };
        }

        public static Enrollment ToGraphType(this PowerSchoolEnrollment powerSchoolEnrollment)
        {
            return new Enrollment()
            {
                GradeLevel = powerSchoolEnrollment.GradeLevel,
                EntryCode = powerSchoolEnrollment.EntryCode,
                EntryDate = powerSchoolEnrollment.EntryDate.ToString(),
                ExitCode = powerSchoolEnrollment.ExitCode,
                ExitDate = powerSchoolEnrollment.ExitDate.ToString(),
                SchoolId = powerSchoolEnrollment.SchoolId,
                DistrictOfResidence = powerSchoolEnrollment.DistrictOfResidence,
                Track = powerSchoolEnrollment.Track
            };
        }

        public static School ToGraphType(this PowerSchoolSchool powerSchoolSchool)
        {
            return new School()
            {
                Id = powerSchoolSchool.Id,
                Name = powerSchoolSchool.Name
            };
        }

        public static Section ToGraphType(this PowerSchoolSection powerSchoolSection)
        {
            return new Section()
            {
                Id = powerSchoolSection.Id.ToString(),
                SchoolId = powerSchoolSection.SchoolId,
                CourseId = powerSchoolSection.CourseId,
                TermId = powerSchoolSection.TermId,
                SectionNumber = powerSchoolSection.SectionNumber,
                Expression = powerSchoolSection.Expression,
                StaffId = powerSchoolSection.StaffId
            };
        }
        
        public static SectionEnrollment ToGraphType(this PowerSchoolSectionEnrollment powerSchoolSectionEnrollment)
        {
            return new SectionEnrollment()
            {
                Section = powerSchoolSectionEnrollment.PowerSchoolSection.ToGraphType(),
                Dropped = powerSchoolSectionEnrollment.Dropped.ToString(),
                EntryDate = powerSchoolSectionEnrollment.ToString() ?? string.Empty,
                ExitDate = powerSchoolSectionEnrollment.ExitDate.ToString(),
                StudentId = powerSchoolSectionEnrollment.StudentId.ToString()
            };
        }

        public static IEnumerable<SectionEnrollment> ToGraphType(
            this IEnumerable<PowerSchoolSectionEnrollment> powerSchoolSectionEnrollments)
        {
            var result = new List<SectionEnrollment>();
            
            foreach (var enrollment in powerSchoolSectionEnrollments)
            {
                result.Add(enrollment.ToGraphType());
            }

            return result;
        }
    }
}