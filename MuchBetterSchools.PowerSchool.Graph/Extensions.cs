using System.Collections.Generic;
using MuchBetterSchools.PowerSchool.Graph.Courses;
using MuchBetterSchools.PowerSchool.Graph.Students;
using MuchBetterSchools.PowerSchool.Services.Course;
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
    }
}