using System;
using System.Collections;
using System.Collections.Generic;
using MuchBetterSchools.PowerSchool.Graph.Courses;
using MuchBetterSchools.PowerSchool.Graph.Enrollments;
using MuchBetterSchools.PowerSchool.Graph.Schools;
using MuchBetterSchools.PowerSchool.Graph.SectionEnrollments;
using MuchBetterSchools.PowerSchool.Services.SectionEnrollments;

namespace MuchBetterSchools.PowerSchool.Graph.Students
{
    public class Student
    {
        public string Id { get; set; } = null!;
        public string StudentNumber { get; set; } = null!;

        public string? StateStudentNumber { get; set; } 

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public string CurrentGradeLevel { get; set; } = null!;
    }
}