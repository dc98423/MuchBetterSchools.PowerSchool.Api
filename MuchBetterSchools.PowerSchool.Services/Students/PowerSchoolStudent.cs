using System;

namespace MuchBetterSchools.PowerSchool.Services.Students
{
    public class PowerSchoolStudent
    {
        public PowerSchoolStudent(
            int studentId,
            string studentNumber,
            string stateStudentNumber,
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            int currentGradeLevel)
        {
            StudentId = studentId;
            StudentNumber = studentNumber;
            StateStudentNumber = stateStudentNumber;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            CurrentGradeLevel = currentGradeLevel;
        }

        public int StudentId { get; }
        
        public string StudentNumber { get; }
        public string StateStudentNumber { get; }

        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }
        public int CurrentGradeLevel { get; }
    }
}