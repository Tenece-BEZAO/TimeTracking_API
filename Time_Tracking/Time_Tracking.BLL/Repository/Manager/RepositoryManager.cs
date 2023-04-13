using Time_Tracking.BLL.Repository.Implementations;
using Time_Tracking.BLL.Repository.Interfaces;
using Time_Tracking.DAL.Entities;

namespace Time_Tracking.BLL.Repository.Manager
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Time_Tracking_DbContext _time_Tracking_DbContext;
        private readonly Lazy<IAdminRepository> _adminRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<ITaskRepository> _taskRepository;
        private readonly Lazy<IAttendanceRepository> _attendanceRepository;

        public RepositoryManager(Time_Tracking_DbContext time_Tracking_DbContext)
        {
            _time_Tracking_DbContext = time_Tracking_DbContext;
            _adminRepository = new Lazy<IAdminRepository>(() => new AdminRepository(time_Tracking_DbContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(time_Tracking_DbContext));
            _taskRepository = new Lazy<ITaskRepository>(() => new TaskRepository(time_Tracking_DbContext));
            _attendanceRepository =
                new Lazy<IAttendanceRepository>(() => new AttendanceRepository(time_Tracking_DbContext));
        }

        public IAdminRepository Admin => _adminRepository.Value;
        public IEmployeeRepository Employee => _employeeRepository.Value;
        public ITaskRepository Todo => _taskRepository.Value;
        public IAttendanceRepository Attendance => _attendanceRepository.Value;
        public async Task SaveAsync() => await _time_Tracking_DbContext.SaveChangesAsync();
    }
}