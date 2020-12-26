using Microsoft.Extensions.DependencyInjection;
using MuchBetterSchools.PowerSchool.Graph;
using MuchBetterSchools.PowerSchool.Graph.Courses;
using MuchBetterSchools.PowerSchool.Graph.Students;
using MuchBetterSchools.PowerSchool.Services.Course;
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
                .AddType<StudentType>()
                .AddType<StudentQuery>()
                .BindResolver<StudentResolvers>()
                .AddQueryType<Query>();
        }
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IPowerSchoolStudentService, PowerSchoolStudentService>();
            services.AddTransient<IPowerSchoolCourseService, PowerSchoolCourseService>();
        }
    }
}