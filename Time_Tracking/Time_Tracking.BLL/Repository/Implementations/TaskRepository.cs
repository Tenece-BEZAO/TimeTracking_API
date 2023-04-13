using Microsoft.EntityFrameworkCore;
using Time_Tracking.BLL.Repository.Base;
using Time_Tracking.BLL.Repository.Interfaces;
using Time_Tracking.DAL.Entities;
using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.BLL.Repository.Implementations;

public class TaskRepository : RepositoryBase<Todo>, ITaskRepository
{
    public TaskRepository(Time_Tracking_DbContext time_Tracking_DbContext)
        : base(time_Tracking_DbContext)
    {
    }

    public IEnumerable<Todo> GetAllTasks(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(c => c.EmployeeId)
            .ToList();

    public async Task<IEnumerable<Todo>> GetTasksByIdAsync(int employeeId, bool trackChanges)
    {
        return await FindByCondition(t => t.EmployeeId == employeeId, trackChanges)
            .ToListAsync();
    }
}