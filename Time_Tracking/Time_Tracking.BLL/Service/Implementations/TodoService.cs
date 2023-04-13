using AutoMapper;
using Time_Tracking.BLL.DTOs;
using Time_Tracking.BLL.LoggerService;
using Time_Tracking.BLL.Repository.Manager;
using Time_Tracking.BLL.Service.Interfaces;
using Time_Tracking.DAL.Entities.Exceptions;

namespace Time_Tracking.BLL.Service.Implementations;

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

    public Task<IEnumerable<TodoDTO>> GetAllTasksAsync(bool trackChanges)
    {
        var tasks = _repository.Todo.GetAllTasks(false);

        if (tasks is null)
            throw new TasksNotFoundException();

        var tasksDto = _mapper.Map<IEnumerable<TodoDTO>>(tasks);

        return Task.FromResult(tasksDto);
    }

    public async Task<IEnumerable<TodoDTO>> GetTasksByIdAsync(int employeeId, bool trackChanges)
    {
        var task = await _repository.Todo.GetTasksByIdAsync(employeeId, trackChanges);

        if (task is null)
            throw new TasksNotFoundException();

        var taskDto = _mapper.Map<IEnumerable<TodoDTO>>(task);

        return taskDto;
    }
}