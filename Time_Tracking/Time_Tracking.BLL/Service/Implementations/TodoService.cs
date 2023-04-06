using AutoMapper;
using Time_Tracking.BLL.LoggerService;
using Time_Tracking.BLL.Repositories;
using Time_Tracking.BLL.Service.Implementations;
using Time_Tracking.BLL.Service.Interfaces;
using Time_Tracking.DAL.Entities.Exceptions;
using Time_Tracking.DAL.Entities.Models;
using Time_Tracking.Shared.DataTransferObjects;

namespace Time_Tracking.BLL.Implementations
{
    internal sealed class TodoService : ITodoService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly EmployeeService _employeeService;
        public TodoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, EmployeeService employeeService)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _employeeService = employeeService;
        }

        public TodoService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
        }


        //this broke
        public async Task<IEnumerable<TaskDTO>> GetAllTasksAsync(bool trackChanges)
        {
            var tasks = (await _employeeService.GetAllEmployeesAsync(trackChanges)).Select(e => e.Tasks).ToList();

            if (tasks is null)
                throw new TasksNotFoundException();

            var tasksDto = _mapper.Map<IEnumerable<TaskDTO>>(tasks);

            return tasksDto;
        }

        public async Task<TaskDTO> GetTaskAsync(int employeeId, int taskId, bool trackChanges)
        {
            var task = await _repository.Todo.GetTaskAsync(employeeId, taskId, trackChanges);

            if (task is null)
                throw new TasksNotFoundException();

            var taskDto = _mapper.Map<TaskDTO>(task);

            return taskDto;
        }

        //come back here and try to modify this
        /*public IEnumerable<TaskDTO> GetAllTasks(bool trackChanges)
        {
            FindAll(trackChanges)
       .OrderBy(c => c.EmployeeId)
       .Join(
           _context.Employees,
           todo => todo.EmployeeId,
           employee => employee.Id,
           (todo, employee) => new TaskDTO
           {
               TaskId = todo.Id,
               TaskName = todo.Name,
               EmployeeName = employee.Name
           }
       )
       .ToList();
        }
        */

        


    }
}
