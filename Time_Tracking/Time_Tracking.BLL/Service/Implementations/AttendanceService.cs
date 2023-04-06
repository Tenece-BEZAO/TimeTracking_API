using AutoMapper;
using Time_Tracking.BLL.LoggerService;
using Time_Tracking.BLL.Repositories;
using Time_Tracking.BLL.Service.Interfaces;
using Time_Tracking.Shared.DataTransferObjects;

namespace Time_Tracking.BLL.Service.Implementations
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AttendanceService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendanceByEmployeeAsync(int employeeId)
        {
            var attendance = await _repository.Attendance.GetAttendanceByEmployeeAsync(employeeId);

            var attendanceDto = _mapper.Map<IEnumerable<AttendanceDTO>>(attendance);

            return attendanceDto;
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAllAttendanceAsync(bool trackChanges)
        {
            var attendance = await _repository.Attendance.GetAllAttendanceAsync(trackChanges);

            var attendanceDto = _mapper.Map<IEnumerable<AttendanceDTO>>(attendance);

            return attendanceDto;
        }
    }
}
