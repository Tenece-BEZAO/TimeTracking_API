using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.DAL.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasData(
            new Employee
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Department = "IT",
                UserId = "1",
            },
            new Employee
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Department = "HR",
                UserId = "2",
            },
            new Employee
            {
                Id = 3,
                FirstName = "Kendrick",
                LastName = "Chukwuka",
                Department = "Software",
                UserId = "3",
            }
        );
    }
}