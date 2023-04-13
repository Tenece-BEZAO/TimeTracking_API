using Time_Tracking.BLL.Repository.Interfaces;

namespace Time_Tracking.BLL.Repositories
{
    public interface IRepositoryManager
    {
        IAdminRepository Admin { get; }
        IEmployeeRepository Employee { get; }
        ITaskRepository Todo { get; }
        IAttendanceRepository Attendance { get; }
        Task SaveAsync();
    }
}
