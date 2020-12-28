using HotChocolate.Types;

namespace MuchBetterSchools.PowerSchool.Graph.Enrollments
{
    public class EnrollmentType : ObjectType<Enrollment>
    {
        protected override void Configure(IObjectTypeDescriptor<Enrollment> descriptor)
        {
            descriptor.Include<EnrollmentResolvers>();
        }
    }
}