using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Time_Tracking.DAL.Entities;

namespace Time_Tracking.API.ContextFactory;

public class TimeTrackingContextFactory : IDesignTimeDbContextFactory<Time_Tracking_DbContext>
{
    public Time_Tracking_DbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<Time_Tracking_DbContext>()
            .UseSqlServer(configuration.GetConnectionString("DefaultConn"),
                db => db.MigrationsAssembly("Time_Tracking.DAL"));
        
        
        return new Time_Tracking_DbContext(builder.Options);
    }
}