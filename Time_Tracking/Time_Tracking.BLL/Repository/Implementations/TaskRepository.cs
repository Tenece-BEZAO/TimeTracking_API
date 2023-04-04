using Microsoft.EntityFrameworkCore;
using Time_Tracking.BLL.Repository.Base;
using Time_Tracking.BLL.Repository.Interfaces;
using Time_Tracking.DAL.Entities.Models;
using Time_Tracking.Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Time_Tracking.BLL.Repository.Implementations
{
    public class TaskRepository : RepositoryBase<Todo>, ITaskRepository
    {
        public TaskRepository(Time_Tracking_DbContext time_Tracking_DbContext)
        : base(time_Tracking_DbContext)
        { }
        public void CreateTask(int employeeId, Todo task)
        {
            task.EmployeeId = employeeId;
            Create(task);
        }
        public IEnumerable<Todo> GetAllTasks(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.EmployeeId)
            .ToList();

        public async Task<Todo> GetTaskAsync(int employeeId, int taskId, bool trackChanges)
        {
            return await FindByCondition(t => t.EmployeeId == employeeId && t.Id == taskId, trackChanges)
                .SingleOrDefaultAsync();
        }       

        public async Task<IEnumerable<Todo>> GetTasksByIdsAsync(GetTaskCollectionRequestDTO request, bool trackChanges) =>
            await FindByCondition(x => request.employeeIds.Contains(x.Id) && request.taskIds.Contains(x.Id), trackChanges)
            .ToListAsync();

    }
}


