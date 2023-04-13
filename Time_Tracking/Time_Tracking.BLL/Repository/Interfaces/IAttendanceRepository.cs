using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.BLL.Repository.Interfaces;

public interface IAttendanceRepository
{
    Task<IEnumerable<Attendance>> GetAllAttendanceAsync(bool trackChanges);
    Task<IEnumerable<Attendance>> GetAttendanceByEmployeeAsync(int employeeId);
}