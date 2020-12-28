using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MuchBetterSchools.PowerSchool.Services.Students
{
    public sealed class PowerSchoolStudentService : IPowerSchoolStudentService
    {
        public readonly ILogger<PowerSchoolStudentService> _logger;
        
        public PowerSchoolStudentService(ILogger<PowerSchoolStudentService> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<PowerSchoolStudent>> GetAll()
        {
            var result = new List<PowerSchoolStudent>();
            
            for (var i = 0; i < 500; i++)
            {
                result.Add(this.MockStudent());
            }

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<PowerSchoolStudent>> GetAll(string schoolId)
        {
            var result = new List<PowerSchoolStudent>();
            
            for (var i = 0; i < 500; i++)
            {
                result.Add(this.MockStudent());
            }

            return await Task.FromResult(result);
        }

        public async Task<PowerSchoolStudent> Get(string studentNumber)
        {
            return await Task.FromResult(this.MockStudent(studentNumber));
        }

        private PowerSchoolStudent MockStudent(string? studentNumber = null)
        {
            return new PowerSchoolStudent(
                new Random().Next(1,1000),
                studentNumber ?? Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                DateTime.Now,
                new Random().Next(1,10));
        }
    }
}