using Time_Tracking.BLL.Service.Interfaces;

namespace Time_Tracking.BLL.Service.Manager
{
    public interface IServiceManager
    {
        IAdminService AdminService { get; }
        IEmployeeService EmployeeService { get; }
        ITodoService TodoService { get; }
        IAttendanceService AttendanceService { get; }
    }
}
