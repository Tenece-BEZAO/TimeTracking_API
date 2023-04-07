using AutoMapper;
using Time_Tracking.BLL.LoggerService;
using Time_Tracking.BLL.Repositories;
using Time_Tracking.BLL.Service.Implementations;
using Time_Tracking.BLL.Service.Interfaces;
using Time_Tracking.BLL.Service.Manager;
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
        public TodoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }      

        public async Task<IEnumerable<TaskDTO>> GetAllTasksAsync(bool trackChanges)
        {
            var tasks = _repository.Todo.GetAllTasks(false);

            if (tasks is null)
                throw new TasksNotFoundException();

            var tasksDto = _mapper.Map<IEnumerable<TaskDTO>>(tasks);

            return tasksDto;
        }

        public async Task<IEnumerable<TaskDTO>> GetTasksByIdAsync(int employeeId, bool trackChanges)
        {
            var task = await _repository.Todo.GetTasksByIdAsync(employeeId, trackChanges);

            if (task is null)
                throw new TasksNotFoundException();

            var taskDto = _mapper.Map<IEnumerable<TaskDTO>>(task);

            return taskDto;
        }


    }
}
