using Time_Tracking.Shared.DataTransferObjects;

namespace Time_Tracking.BLL.Service.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TaskDTO>> GetAllTasksAsync(bool trackChanges);
        Task<TaskDTO> GetTaskAsync(int employeeId, int taskId, bool trackChanges);
        
               
    }
}
