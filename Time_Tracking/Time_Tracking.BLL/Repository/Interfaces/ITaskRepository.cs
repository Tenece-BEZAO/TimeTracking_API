using Time_Tracking.DAL.Entities.Models;
using Time_Tracking.Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Time_Tracking.BLL.Repository.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<Todo> GetAllTasks(bool trackChanges);
        Task<IEnumerable<Todo>> GetTasksByIdAsync(int employeeId, bool trackChanges);

    }
}
