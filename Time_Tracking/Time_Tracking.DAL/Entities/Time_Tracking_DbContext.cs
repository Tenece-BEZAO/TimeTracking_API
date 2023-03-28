using Microsoft.EntityFrameworkCore;

namespace Time_Tracking.DAL.Entities
{
    public class Time_Tracking_DbContext : DbContext
    {
        public Time_Tracking_DbContext(DbContextOptions<Time_Tracking_DbContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Todo> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
