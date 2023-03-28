using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Time_Tracking.DAL.Entities;
using Time_Tracking.DAL.Enums;

namespace Time_Tracking.DAL.Seed
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
                await context.Employees.AddRangeAsync(GetEmployeesWithTasks());
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
                    Password = "12345",
                    Employees = (IList<Employee>)GetEmployeesWithTasks()
                }
            };
        }
        private static IEnumerable<Employee> GetEmployeesWithTasks()
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
                    AdminId = 1,
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
                    AdminId = 1,
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
                    AdminId = 1,
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

//JFKJBJKFDKFSOBJDFIFHSOI