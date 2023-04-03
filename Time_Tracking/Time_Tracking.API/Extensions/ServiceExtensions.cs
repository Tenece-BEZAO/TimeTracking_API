
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Time_Tracking.API.ExceptionHandling.Interfaces;
using Time_Tracking.API.ExceptionHandling.LoggerService;
using Time_Tracking.BLL.Implementations;
using Time_Tracking.BLL.Interfaces;
using Time_Tracking.DAL.Entities;
using Time_Tracking.DAL.Interfaces;

namespace Time_Tracking.API.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services) =>
          services.AddCors(options =>
          {
              options.AddPolicy("CorsPolicy", builder =>
              builder.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
          });


        public static void ConfigureIISIntegration(this IServiceCollection services) =>
          services.Configure<IISOptions>(options =>
          {

          });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
          services.AddSingleton<ILoggerManager, LoggerManager>();



        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<Time_Tracking_DbContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("DefaultConn")));

        public static void ConfigureServices(this IServiceCollection services)
        {


            services.AddScoped<IUnitOfWork, UnitOfWork<Time_Tracking_DbContext>>();


            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<Time_Tracking_DbContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IEmployeeService, EmployeeService>();
        }

    }
}
