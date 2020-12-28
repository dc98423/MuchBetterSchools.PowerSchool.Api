using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MuchBetterSchools.PowerSchool.Services.Course
{
    public sealed class PowerSchoolCourseService : IPowerSchoolCourseService
    {
        public async Task<IEnumerable<PowerSchoolCourse>> GetAll()
        {
            var result = new List<PowerSchoolCourse>();

            for (int i = 0; i < 100; i++)
            {
                result.Add(new PowerSchoolCourse(Guid.NewGuid().ToString()));
            }

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<PowerSchoolCourse>> GetAllForStudent(string studentNumber, CancellationToken token)
        {
            var result = new List<PowerSchoolCourse>();

            for (int i = 0; i < 100; i++)
            {
                result.Add(new PowerSchoolCourse(Guid.NewGuid().ToString()));
            }

            return await Task.FromResult(result);
        }
    }
}