using NLog;
using Time_Tracking.Presentation.Controllers;
using Microsoft.AspNetCore.HttpOverrides;
using Time_Tracking.API.Extensions;
using Time_Tracking.BLL.LoggerService;

namespace Time_Tracking.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            builder.Services.ConfigureCors();
            builder.Services.ConfigureIISIntegration();
            builder.Services.ConfigureServiceManager();
            builder.Services.ConfigureLoggerService();
            builder.Services.ConfigureRepositoryManager();
          
            builder.Services.ConfigureSqlContext(builder.Configuration);

            builder.Services.AddAutoMapper(typeof(Program));

            // Add services to the container.

            builder.Services.AddControllers()
                .AddApplicationPart(typeof(Time_Tracking.Presentation.AssemblyReference).Assembly);
            
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            var logger = app.Services.GetRequiredService<ILoggerManager>();
            app.ConfigureExceptionHandler(logger);
            if (app.Environment.IsProduction())
                app.UseHsts();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseCors("CorsPolicy");

            app.UseAuthorization();
            
            app.MapControllers();
            
            await app.RunAsync();
        }
    }
}