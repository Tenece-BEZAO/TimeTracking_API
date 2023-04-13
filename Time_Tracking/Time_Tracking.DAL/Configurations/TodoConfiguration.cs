using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Time_Tracking.DAL.Entities.Enums;
using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.DAL.Configurations;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.HasData(
            new Todo
            {
                Id = 1,
                Title = "Fix bug",
                Description = "There's a bug in the login page",
                DueAt = DateTime.Now.AddDays(1),
                EmployeeId = 1,
                State = State.NotStarted
            },
            new Todo
            {
                Id = 2,
                Title = "Update documentation",
                Description = "Update the user manual with new features",
                DueAt = DateTime.Now.AddDays(3),
                EmployeeId = 1,
                State = State.NotStarted
            },
            new Todo
            {
                Id = 3,
                Title = "Interview candidates",
                Description = "Interview candidates for the open position",
                DueAt = DateTime.Now.AddDays(2),
                EmployeeId = 2,
                State = State.NotStarted
            },
            new Todo
            {
                Id = 4,
                Title = "Review resumes",
                Description = "Review resumes of the candidates",
                DueAt = DateTime.Now.AddDays(1),
                EmployeeId = 2,
                State = State.NotStarted
            },
            new Todo
            {
                Id = 5,
                Title = "Testing Endpoints",
                Description = "Checking To see workables",
                DueAt = DateTime.Now.AddDays(1),
                EmployeeId = 2,
                State = State.NotStarted
            },
            new Todo
            {
                Id = 6,
                Title = "Run a Race",
                Description = "SetUp a sprint",
                DueAt = DateTime.Now.AddDays(4),
                EmployeeId = 3,
                State = State.NotStarted
            }
        );
    }
}