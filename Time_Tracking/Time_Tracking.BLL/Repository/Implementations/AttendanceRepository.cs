using Microsoft.EntityFrameworkCore;
using Time_Tracking.BLL.Repository.Base;
using Time_Tracking.BLL.Repository.Interfaces;
using Time_Tracking.DAL.Entities;
using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.BLL.Repository.Implementations
{
    public class AttendanceRepository : RepositoryBase<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(Time_Tracking_DbContext time_Tracking_DbContext) : base(time_Tracking_DbContext)
        { }

        public async Task<IEnumerable<Attendance>> GetAttendanceByEmployeeAsync(int employeeId)
        {
            return await FindByCondition(a => a.EmployeeId == employeeId).ToListAsync();
        }
        public async Task<IEnumerable<Attendance>> GetAllAttendanceAsync(bool trackChanges = false)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
        public void SaveAsync() => Time_Tracking_DbContext.SaveChangesAsync();
    }
}
