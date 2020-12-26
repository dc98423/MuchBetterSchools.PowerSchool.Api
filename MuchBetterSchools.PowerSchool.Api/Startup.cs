using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MuchBetterSchools.PowerSchool.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "MuchBetterSchools.PowerSchool.Api", Version = "v1"});
            });
            
            services.AddDomainServices();
            services.AddGraphServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MuchBetterSchools.PowerSchool.Api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); endpoints.MapGraphQL(); });
        }
    }
}