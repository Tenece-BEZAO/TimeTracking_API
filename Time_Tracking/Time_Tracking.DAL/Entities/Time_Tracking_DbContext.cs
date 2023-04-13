using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Time_Tracking.DAL.Configurations;
using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.DAL.Entities
{
    public class Time_Tracking_DbContext : IdentityDbContext<ApplicationUser>
    {
        public Time_Tracking_DbContext(DbContextOptions<Time_Tracking_DbContext> options, DbSet<Admin> admins, DbSet<Employee> employees, DbSet<Todo> tasks, DbSet<Attendance> attendances) : base(options)
        {
            Admins = admins;
            Employees = employees;
            Tasks = tasks;
            Attendances = attendances;
        }


        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Todo> Tasks { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TodoConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Admin) // Employee has one Admin
                .WithMany(a => a.Employees) // Admin has many Employees
                .HasForeignKey(e => e.AdminId) // Foreign key property in Employee entity
                .IsRequired();

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