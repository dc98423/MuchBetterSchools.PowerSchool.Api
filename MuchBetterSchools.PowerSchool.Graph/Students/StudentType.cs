using HotChocolate.Types;

namespace MuchBetterSchools.PowerSchool.Graph.Students
{
    public class StudentType : ObjectType<Student>
    {
        protected override void Configure(IObjectTypeDescriptor<Student> descriptor)
        {
            descriptor.Include<StudentResolvers>();
        }
    }
}