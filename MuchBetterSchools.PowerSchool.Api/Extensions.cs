using Microsoft.Extensions.DependencyInjection;
using MuchBetterSchools.PowerSchool.Graph;
using MuchBetterSchools.PowerSchool.Graph.Courses;
using MuchBetterSchools.PowerSchool.Graph.Enrollments;
using MuchBetterSchools.PowerSchool.Graph.SectionEnrollments;
using MuchBetterSchools.PowerSchool.Graph.Sections;
using MuchBetterSchools.PowerSchool.Graph.Students;
using MuchBetterSchools.PowerSchool.Services.Course;
using MuchBetterSchools.PowerSchool.Services.Enrollments;
using MuchBetterSchools.PowerSchool.Services.Schools;
using MuchBetterSchools.PowerSchool.Services.SectionEnrollments;
using MuchBetterSchools.PowerSchool.Services.Sections;
using MuchBetterSchools.PowerSchool.Services.Students;

namespace MuchBetterSchools.PowerSchool.Api
{
    public static class Extensions
    {
        public static void AddGraphServices(this IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                .AddType<CourseType>()
                .AddType<Enrollment>()
                .AddType<Section>()
                .AddType<SectionEnrollment>()
                .AddType<StudentType>()
                .AddType<StudentQuery>()
                .BindResolver<StudentResolvers>()
                .AddQueryType<Query>();
        }
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IPowerSchoolSchoolService, PowerSchoolSchoolService>();
            services.AddTransient<IPowerSchoolEnrollmentService, PowerSchoolEnrollmentService>();
            services.AddTransient<IPowerSchoolStudentService, PowerSchoolStudentService>();
            services.AddTransient<IPowerSchoolCourseService, PowerSchoolCourseService>();
            services.AddTransient<IPowerSchoolSectionService, PowerSchoolSectionService>();
            services.AddTransient<IPowerSchoolSectionEnrollmentService, PowerSchoolSectionEnrollmentService>();
        }
    }
}