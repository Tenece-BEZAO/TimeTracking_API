using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Time_Tracking.BLL.DTOs;
using Time_Tracking.BLL.Interfaces;
using Time_Tracking.DAL.Entities;
using Time_Tracking.DAL.Enums;
using Time_Tracking.DAL.Interfaces;
using System.Linq;
using Time_Tracking.BLL.Implementations.EmployeeExtension;
using Time_Tracking.DAL.DTOs;

namespace Time_Tracking.BLL.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<Todo> _todoRepo;
        private readonly IRepository<Attendance> _attendanceRepo;
        private readonly IRepository<Employee> _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _todoRepo = _unitOfWork.GetRepository<Todo>();
            _attendanceRepo = _unitOfWork.GetRepository<Attendance>();
            _employeeRepo = _unitOfWork.GetRepository<Employee>();
         
        }


        public async Task<string> ClockInAsync(string employeeId)
        {
            var employee = await _userManager.FindByIdAsync(employeeId);
            if (employee == null)
            {
                throw new ArgumentException("Invalid employee id");
            }

            var attendanceDto = new AttendanceDTO
            {
                EmployeeId = employee.Id,
                ClockIn = DateTime.Now
            };

            var attendance = _mapper.Map<Attendance>(attendanceDto);

            await _attendanceRepo.AddAsync(attendance);

            
            var employeeName = await _userManager.GetUserNameAsync(employee);

            return $" Welcome {employeeName}, You have clocked in at {attendance.ClockIn}";
        }


        public async Task<string> ClockOutAsync(string employeeId)
        {
            var user = await _userManager.FindByIdAsync(employeeId);
            if (user == null)
            {
                throw new ArgumentException($"User with ID {employeeId} not found.");
            }

            var employee = await _employeeRepo.GetByIdAsync(int.Parse(employeeId));
            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), employeeId);
            }

            var attendance = await _attendanceRepo.GetFirstOrDefaultAsync(
                a => a.EmployeeId == employee.Id && !a.ClockOut.HasValue,
                include: q => q.Include(a => a.Employee)
            );

            if (attendance == null)
            {
                throw new ArgumentException($"User with ID {employeeId} has not clocked in yet.");
            }
            if (attendance.ClockOut.HasValue)
            {
                throw new InvalidOperationException("Employee has already clocked out for today.");
            }

            attendance.ClockOut = DateTime.Now;

            await _attendanceRepo.UpdateAsync(attendance);

            var employeeName = await _userManager.GetUserNameAsync(user);
            return $"Employee {employeeName} has clocked out at {attendance.ClockOut}.";
        }








        /*   public async Task<UserManagerResponse> CreateTaskAsync(string employeeId, TodoDTO todoDto)
           {
               int employeeIdInt = Int32.Parse(employeeId);
               var employee = await _employeeRepo.GetByIdAsync(employeeIdInt);
               if (employee == null)
               {
                   throw new Exception("Employee not found");
               }

               var todo = _mapper.Map<Todo>(todoDto);

               todo.CreatedAt = DateTime.UtcNow;

               todo.EmployeeId = employee.Id;

               await _todoRepo.AddAsync(todo);

               var createdTodoDto = _mapper.Map<TodoDTO>(todo);

               return new UserManagerResponse
               {
                   Message = $"Todo successfully created by {employee.FirstName} {employee.LastName}",
                   TodoDto = createdTodoDto,
                   IsSuccess = true
               };
           }*/

        public async Task<UserManagerResponse> CreateTaskAsync(string employeeId, TodoDTO todoDto)
        {
            int employeeIdInt = Int32.Parse(employeeId);
            var employee = await _employeeRepo.GetByIdAsync(employeeIdInt);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            var todo = _mapper.Map<Todo>(todoDto);

            todo.CreatedAt = DateTime.UtcNow;

            todo.Employee = employee;

            await _todoRepo.AddAsync(todo);

            var createdTodoDto = _mapper.Map<TodoDTO>(todo);

            return new UserManagerResponse
            {
                Message = $"Todo successfully created by {employee.FirstName} {employee.LastName}",
                TodoDto = createdTodoDto,
                IsSuccess = true
            };
        }







        public async Task<UserManagerResponse> StartTaskAsync(string employeeId, int todoId)
            {
                int employeeIdInt = Int32.Parse(employeeId);
                var employee = await _employeeRepo.GetByIdAsync(employeeIdInt);
                if (employee == null)
                {
                    throw new Exception("Employee not found");
                }

                var todo = await _todoRepo.GetByIdAsync(todoId);
                if (todo == null)
                {
                    throw new Exception("Todo not found");
                }

                if (todo.State == State.NotStarted)
                {
                    todo.State = State.InProgress;
                    await _todoRepo.UpdateAsync(todo); 
                }

                var todoDto = _mapper.Map<TodoDTO>(todo);
                        
                todoDto.State = new TodoStateDTO { Name = todo.State.ToString() };
                            
                todoDto.Priority = _mapper.Map<PriorityDTO>(todo.Priority);



                return new UserManagerResponse
                {
                            Message = $"The employee {employee.FirstName} {employee.LastName} has started the todo with a title of {todoDto.Title}.",
                            TodoDto = todoDto,
                            IsSuccess = true
                };
                
            }





        public async Task<IEnumerable<TodoDTO>> GetDailySummaryAsync(string employeeId)
        {
            var employee = await _userManager.FindByIdAsync(employeeId);
            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), employeeId);
            }

            var today = DateTime.Today;

            var todos = await _todoRepo.GetAllAsync(
                filter: t => t.Employee.Id == int.Parse(employee.Id)
                    && t.CreatedAt.Date == today
                    && t.State == State.InProgress, // Filter tasks that are in progress
                include: q => q.Include(t => t.Employee));

            var todoDtos = _mapper.Map<IEnumerable<TodoDTO>>(todos)
                .OrderByDescending(t => t.CreatedAt)
                .ToList();

            return todoDtos;
        }





        public async Task<UserManagerResponse> ImportPendingTasksAsync(string employeeId)
        {
            var employee = await _employeeRepo.GetFirstOrDefaultAsync(
                e => e.Id.ToString() == employeeId,
                include: e => e.Include(e => e.Todos)
            );

            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), employeeId);
            }

            var overdueTasks = employee.Todos.Where(t => t.DueAt < DateTime.Now && t.State != State.Completed);
            var pendingTasks = employee.Todos.Where(t => t.State == State.InProgress || t.State == State.Paused);

            foreach (var task in overdueTasks.Concat(pendingTasks))
            {
                if (task.State == State.InProgress)
                {
                    task.State = State.Paused;
                }
                else
                {
                    task.State = State.NotStarted;
                }

                _todoRepo.Update(task);
            }

            var todoDtos = overdueTasks.Concat(pendingTasks)
                                       .Select(t => _mapper.Map<TodoDTO>(t))
                                       .ToList();

            return new UserManagerResponse
            {
                Message = $"Successfully imported {todoDtos.Count} pending tasks.",
                TodoDtos = todoDtos,
                IsSuccess = true
            };
        }






        public async Task<UserManagerResponse> StopTaskAsync(string employeeId, int todoId)
        {
            int employeeIdInt = Int32.Parse(employeeId);
            var employee = await _employeeRepo.GetByIdAsync(employeeIdInt);
            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), employeeId);
            }

            var task = await _todoRepo.GetFirstOrDefaultAsync(t => t.EmployeeId == int.Parse(employeeId) && t.Id == todoId);
            if (task == null)
            {
                throw new NotFoundException(nameof(Todo), todoId.ToString());
            }

            if (task.State != State.InProgress)
            {
                throw new InvalidOperationException("Task is not in progress.");
            }

            task.State = State.Paused;
            _todoRepo.Update(task);

            var todoDto = _mapper.Map<TodoDTO>(task);
            todoDto.State = new TodoStateDTO { Name = task.State.ToString() };
            todoDto.Priority = _mapper.Map<PriorityDTO>(task.Priority);

            return new UserManagerResponse
            {
                Message = $"The employee {employee.FirstName} {employee.LastName} has stopped the task with a title of {todoDto.Title}.",
                TodoDto = todoDto,
                IsSuccess = true
            };
        }


    }
}
