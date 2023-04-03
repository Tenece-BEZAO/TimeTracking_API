using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Time_Tracking.DAL.Configurations;

namespace Time_Tracking.DAL.Entities
{
    public class Time_Tracking_DbContext : IdentityDbContext<ApplicationUser>
    {
        public Time_Tracking_DbContext(DbContextOptions<Time_Tracking_DbContext> options) : base(options)
        {
        }

      

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            modelBuilder.ApplyConfiguration(new TodoConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Attendance)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Todos)
                .WithOne(t => t.Employee)
                .HasForeignKey(t => t.EmployeeId) 
                .IsRequired();

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Attendance)
                .HasForeignKey(a => a.EmployeeId)
                .IsRequired()
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Todo>()
                .HasOne(t => t.Employee)
                .WithMany(e => e.Todos)
                .HasForeignKey(t => t.EmployeeId) 
                .IsRequired();

            modelBuilder.Entity<Todo>()
                .Property(t => t.State)
                .HasConversion<string>();

            modelBuilder.Entity<Todo>()
                .Property(t => t.Priority)
                .HasConversion<string>();

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .IsRequired();
        }


    }



}





