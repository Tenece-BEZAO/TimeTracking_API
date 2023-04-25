using Time_Tracking.BLL.Repository.Interfaces;

namespace Time_Tracking.BLL.Repository.Manager
{
    public interface IRepositoryManager
    {
        IEmployeeRepository Employee { get; }
        ITaskRepository Todo { get; }
        IAttendanceRepository Attendance { get; }
        Task SaveAsync();
    }
}
