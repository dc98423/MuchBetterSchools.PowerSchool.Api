using System.Collections.Generic;
using MuchBetterSchools.PowerSchool.Graph.Courses;

namespace MuchBetterSchools.PowerSchool.Graph.Students
{
    public class Student
    {
        public string StudentNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
 
        public IEnumerable<Course> Courses { get; set; }
    }
}