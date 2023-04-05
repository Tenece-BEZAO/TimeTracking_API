using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;
using NLog;
using System.Reflection;
using Time_Tracking.API.Extensions;
using Time_Tracking.DAL.ExceptionHandling.Exceptions;
using Time_Tracking.DAL.ExceptionHandling.Interfaces;

namespace Time_Tracking.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));



            builder.Services.ConfigureCors();
            builder.Services.ConfigureIISIntegration();
            builder.Services.ConfigureLoggerService();
            builder.Services.ConfigureSqlContext(builder.Configuration);
            builder.Services.ConfigureServices();





            builder.Services.AddSwaggerGen(sw =>
            {

                sw.EnableAnnotations();
                sw.SwaggerDoc("v1", new OpenApiInfo { Title = "TimeTrackingAPI", Version = "1.0" });
            });

            



            builder.Services.AddAutoMapper(Assembly.Load("Time_Tracking.BLL"));


            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();



            var logger = app.Services.GetRequiredService<ILoggerManager>();
            app.ConfigureExceptionHandler(logger);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseCors("CorsPolicy");


            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}