using MuchBetterSchools.PowerSchool.Services.Enrollments;

namespace MuchBetterSchools.PowerSchool.Services.Schools
{
    public class PowerSchoolSchool
    {
        public PowerSchoolSchool(string id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public string Id { get; }
        
        public string Name { get; }

    }
}