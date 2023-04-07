using Microsoft.EntityFrameworkCore;
using Time_Tracking.BLL.LoggerService;
using Time_Tracking.BLL.Repositories;
using Time_Tracking.BLL.Service.Interfaces;
using Time_Tracking.BLL.Service.Manager;
using Time_Tracking.DAL.Entities.Models;

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

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
                services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
                services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
                services.AddDbContext<Time_Tracking_DbContext>(opts =>
                    opts.UseSqlServer(configuration.GetConnectionString("default"),
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.EnableRetryOnFailure(
                                maxRetryCount: 5,
                                maxRetryDelay: TimeSpan.FromSeconds(30),
                                errorNumbersToAdd: null);
                        }));
    }
}

