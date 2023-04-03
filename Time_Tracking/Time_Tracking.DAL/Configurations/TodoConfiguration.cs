using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_Tracking.DAL.Entities;
using Time_Tracking.DAL.Enums;

namespace Time_Tracking.DAL.Configurations
{
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
                }
            );
        }
    }

}
