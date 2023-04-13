using Time_Tracking.Shared.DataTransferObjects;

namespace Time_Tracking.BLL.Service.Interfaces
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDTO>> GetAttendanceByEmployeeAsync(int employeeId);
        Task<IEnumerable<AttendanceDTO>> GetAllAttendanceAsync(bool trackChanges);
        
    }
}
