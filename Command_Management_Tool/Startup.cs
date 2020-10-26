using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Command_Management_Tool.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Command_Management_Tool
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // default service, seems to register Controller:
            services.AddControllers();
            // register Repository to decouple DBContext:
            services.AddScoped<ICMTRepo, SqlCMTRepo>();
            // register DBContext with specified physical DB from connection string in appsettings.json Configuration file:
            services.AddDbContext<CMTContext>(
                opt => opt.UseSqlServer(
                    Configuration.GetConnectionString("CMTConnection")
                )
            );
            // register AutoMapper to current assembly
            services.AddAutoMapper(
                AppDomain.CurrentDomain.GetAssemblies()
            );
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
