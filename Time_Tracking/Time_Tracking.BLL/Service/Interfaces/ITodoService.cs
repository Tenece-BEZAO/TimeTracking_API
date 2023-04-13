using Time_Tracking.BLL.DTOs;

namespace Time_Tracking.BLL.Service.Interfaces;

public interface ITodoService
{
    Task<IEnumerable<TodoDTO>> GetAllTasksAsync(bool trackChanges);
    Task<IEnumerable<TodoDTO>> GetTasksByIdAsync(int employeeId, bool trackChanges);
}