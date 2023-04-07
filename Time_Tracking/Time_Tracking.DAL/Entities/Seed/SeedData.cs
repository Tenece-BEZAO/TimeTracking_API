using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Time_Tracking.DAL.Entities.Models;
using Time_Tracking.DAL.Enums;

namespace Time_Tracking.DAL.Entities.Seed
{
    public class SeedData
    {
        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            Time_Tracking_DbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<Time_Tracking_DbContext>();

            if (!await context.Admins.AnyAsync())
            {
                await context.Admins.AddRangeAsync(GetAdmins());
                await context.SaveChangesAsync();
            }

            if (!await context.Employees.AnyAsync())
            {
                await context.Employees.AddRangeAsync(GetEmployeesWithTasksAndAttendanceHistory());
                await context.SaveChangesAsync();
            }

        }

        private static IEnumerable<Admin> GetAdmins()
        {
            return new List<Admin>()
            {
                new Admin()
                {
                    FullName = "Alex Doe",
                    PhoneNumber = "0810-000-5678",
                    Email = "a.doe@domain.com",
                    Password = "12345"
                }
            };
        }
        private static IEnumerable<Employee> GetEmployeesWithTasksAndAttendanceHistory()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    FullName = "Chukwuma Doe",
                    PhoneNumber = "0808-111-1111",
                    Email = "c.doe@domain.com",
                    Password = "11111",
                    Department = "Bezao",                    
                    AttendanceHistory = new List<Attendance>()
                    {
                        new Attendance
                        {
                            EmployeeId = 1,
                            ClockedIn = true,
                            ClockedOut = true,
                            ClockInTime = DateTime.Parse("05/03/2023 07:22:16"),
                            ClockOutTime = DateTime.Parse("05/03/2023 17:03:22")
                        },
                        new Attendance
                        {
                            EmployeeId = 1,
                            ClockedIn = true,
                            ClockedOut = true,
                            ClockInTime = DateTime.Parse("06/03/2023 07:13:19"),
                            ClockOutTime = DateTime.Parse("06/03/2023 17:00:12")
                        },
                        new Attendance
                        {
                            EmployeeId = 1,
                            ClockedIn = true,
                            ClockedOut = true,
                            ClockInTime = DateTime.Parse("07/03/2023 07:36:01"),
                            ClockOutTime = DateTime.Parse("07/03/2023 17:01:02")
                        }
                    },
                    Tasks = new List<Todo>()
                    {
                        new Todo
                        {
                            Title = "Do some research",
                            Description = "Research on time tracking apps for inspiration",
                            DueAt = DateTime.Now.AddHours(1),
                            State = State.InProgress,
                            Priority = Priority.High

                        },

                        new Todo
                        {
                            Title = "Consult the book",
                            Description = "Gain more knowledge about how to build Web APIs",
                            DueAt = DateTime.Now.AddHours(5),
                            State = State.NotStarted,
                            Priority = Priority.High


                        },
                        new Todo
                        {
                            Title = "Find something to eat",
                            Description = "Fuel the tank",
                            DueAt = DateTime.Now.AddHours(3),
                            State = State.NotStarted,
                            Priority = Priority.High
                        }
                    }

                },

                new Employee()
                {
                    FullName = "Kendrick Doe",
                    PhoneNumber = "0808-222-2222",
                    Email = "k.doe@domain.com",
                    Password = "22222",
                    Department = "Bezao",                    
                    AttendanceHistory = new List<Attendance>()
                    {
                        new Attendance
                        {
                            EmployeeId = 2,
                            ClockedIn = true,
                            ClockedOut = true,
                            ClockInTime = DateTime.Parse("05/03/2023 07:22:16"),
                            ClockOutTime = DateTime.Parse("05/03/2023 17:01:22")
                        },
                        new Attendance
                        {
                            EmployeeId = 2,
                            ClockedIn = true,
                            ClockedOut = true,
                            ClockInTime = DateTime.Parse("06/03/2023 07:07:19"),
                            ClockOutTime = DateTime.Parse("06/03/2023 17:03:12")
                        },
                        new Attendance
                        {
                            EmployeeId = 2,
                            ClockedIn = true,
                            ClockedOut = true,
                            ClockInTime = DateTime.Parse("07/03/2023 07:34:01"),
                            ClockOutTime = DateTime.Parse("07/03/2023 17:06:02")
                        }

                    },
                    Tasks = new List<Todo>()
                    {
                        new Todo
                        {
                            Title = "Watch some YouTube videos",
                            Description = "Watch some YouTube videos on Web API for clarity",
                            DueAt = DateTime.Now.AddHours(2),
                            State = State.InProgress,
                            Priority = Priority.High

                        },

                        new Todo
                        {
                            Title = "Consult the book",
                            Description = "Gain more knowledge about how to build Web APIs",
                            DueAt = DateTime.Now.AddHours(6),
                            State = State.NotStarted,
                            Priority = Priority.High


                        },
                        new Todo
                        {
                            Title = "Find something to eat",
                            Description = "Fuel the tank",
                            DueAt = DateTime.Now.AddHours(4),
                            State = State.NotStarted,
                            Priority = Priority.High
                        }
                    }

                },

                new Employee()
                {
                    FullName = "Goodness Doe",
                    PhoneNumber = "0808-333-3333",
                    Email = "g.doe@domain.com",
                    Password = "33333",
                    Department = "Bezao",
                    AttendanceHistory = new List<Attendance>()
                    {
                        new Attendance
                        {
                            EmployeeId = 3,
                            ClockedIn = true,
                            ClockedOut = true,
                            ClockInTime = DateTime.Parse("05/03/2023 07:03:16"),
                            ClockOutTime = DateTime.Parse("05/03/2023 17:14:22")
                        },
                        new Attendance
                        {
                            EmployeeId = 3,
                            ClockedIn = true,
                            ClockedOut = true,
                            ClockInTime = DateTime.Parse("06/03/2023 07:09:19"),
                            ClockOutTime = DateTime.Parse("06/03/2023 17:07:12")
                        },
                        new Attendance
                        {
                            EmployeeId = 3,
                            ClockedIn = true,
                            ClockedOut = true,
                            ClockInTime = DateTime.Parse("07/03/2023 07:35:01"),
                            ClockOutTime = DateTime.Parse("07/03/2023 17:09:02")
                        }
                    },
                    Tasks = new List<Todo>()
                    {
                        new Todo
                        {
                            Title = "Digest the book",
                            Description = "Study the recommended book to stupor",
                            DueAt = DateTime.Now.AddHours(4),
                            State = State.InProgress,
                            Priority = Priority.High

                        },

                        new Todo
                        {
                            Title = "Find something to eat",
                            Description = "Fuel the tank",
                            DueAt = DateTime.Now.AddHours(4),
                            State = State.NotStarted,
                            Priority = Priority.High
                        },

                        new Todo
                        {
                            Title = "Watch some YouTube videos",
                            Description = "Watch some YouTube videos on Web API for clarity",
                            DueAt = DateTime.Now.AddHours(2),
                            State = State.NotStarted,
                            Priority = Priority.High

                        }
                    }

                },

            };
        }


    }
}
