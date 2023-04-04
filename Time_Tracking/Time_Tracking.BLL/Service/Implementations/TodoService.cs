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

        public async Task<IEnumerable<TaskDTO>> GetTasksByIdsAsync(GetTaskCollectionRequestDTO request, bool trackChanges)
        {
            if (request is null)
                throw new IdParametersBadRequestException();

            var taskEntities = await _repository.Todo.GetTasksByIdsAsync(request, trackChanges);

            if (request.employeeIds.Count() != taskEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var tasksToReturn = _mapper.Map<IEnumerable<TaskDTO>>(taskEntities);

            return tasksToReturn;
        }

        public async Task<TaskDTO> CreateTaskAsync(int employeeId, CreatingTaskDTO creatingTask, bool trackChanges)
        {
            var employee = await _repository.Employee.GetEmployeeAsync(employeeId, trackChanges);

            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var taskEntity = _mapper.Map<Todo>(creatingTask);

            _repository.Todo.CreateTask(employeeId, taskEntity);

            _repository.SaveAsync();

            var taskToReturn = _mapper.Map<TaskDTO>(taskEntity);

            return taskToReturn;
        }
    }
}
