using Time_Tracking.Shared.DataTransferObjects;

namespace Time_Tracking.BLL.Service.Interfaces
{
    public interface IAttendanceService
    {
        void ClockIn(int employeeId);
        void ClockOut(int employeeId);
        Task<IEnumerable<AttendanceDTO>> GetAttendanceByEmployeeAsync(int employeeId);
        Task<IEnumerable<AttendanceDTO>> GetAttendanceByDateAsync(DateTime date, bool trackChanges);
        Task<IEnumerable<AttendanceDTO>> GetAttendanceForEmployeesByDateAsync(DateTime date, IEnumerable<int> employeeIds, bool trackChanges);
        Task<IEnumerable<AttendanceDTO>> GetAllAttendanceAsync(bool trackChanges);
        
    }
}
