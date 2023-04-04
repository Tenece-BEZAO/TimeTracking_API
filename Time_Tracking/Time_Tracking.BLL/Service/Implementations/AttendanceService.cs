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

        public void ClockIn(int employeeId)
        {
            var clockIn = _repository.Attendance.ClockIn;
        }

        public void ClockOut(int employeeId)
        {
            var clockOut = _repository.Attendance.ClockOut;
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendanceByDateAsync(DateTime date, bool trackChanges)
        {
            var attendance = await _repository.Attendance.GetAttendanceByDateAsync(date, trackChanges);

            var attendanceDto = _mapper.Map<IEnumerable<AttendanceDTO>>(attendance);

            return attendanceDto;
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendanceByEmployeeAsync(int employeeId)
        {
            var attendance = await _repository.Attendance.GetAttendanceByEmployeeAsync(employeeId);

            var attendanceDto = _mapper.Map<IEnumerable<AttendanceDTO>>(attendance);

            return attendanceDto;
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendanceForEmployeesByDateAsync(DateTime date, IEnumerable<int> employeeIds, bool trackChanges)
        {
            var attendance = await _repository.Attendance.GetAttendanceForEmployeesByDateAsync(date, employeeIds, trackChanges);

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
