using AutoMapper;
using Time_Tracking.BLL.Implementations;
using Time_Tracking.BLL.LoggerService;
using Time_Tracking.BLL.Repositories;
using Time_Tracking.BLL.Service.Implementations;
using Time_Tracking.BLL.Service.Interfaces;

namespace Time_Tracking.BLL.Service.Manager
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAdminService> _adminService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<ITodoService> _todoService;
        private readonly Lazy<IAttendanceService> _attendanceService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _adminService = new Lazy<IAdminService>(() => new AdminService(repositoryManager, logger, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper));
            _todoService = new Lazy<ITodoService>(() => new TodoService(repositoryManager, logger, mapper));
            _attendanceService = new Lazy<IAttendanceService>(() => new AttendanceService(repositoryManager, logger, mapper));
        }
        public IAdminService AdminService => _adminService.Value;
        public IEmployeeService EmployeeService => _employeeService.Value;
        public ITodoService TodoService => _todoService.Value;  
        public IAttendanceService AttendanceService => _attendanceService.Value;    
    }

}
