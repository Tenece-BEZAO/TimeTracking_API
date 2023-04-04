using Microsoft.EntityFrameworkCore;
using Time_Tracking.BLL.Repository.Base;
using Time_Tracking.BLL.Repository.Interfaces;
using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.BLL.Repository.Implementations
{
    public class AttendanceRepository : RepositoryBase<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(Time_Tracking_DbContext time_Tracking_DbContext) : base(time_Tracking_DbContext)
        { }

        public void SaveAsync() => Time_Tracking_DbContext.SaveChangesAsync();
        public void ClockIn(int employeeId)
        {
            var attendance = new Attendance
            {
                EmployeeId = employeeId,
                ClockInTime = DateTime.Now
            };

             Create(attendance);
             SaveAsync();
        }

        public void ClockOut(int employeeId)
        {
            var attendance = FindByCondition(a => a.EmployeeId == employeeId && !a.ClockedOut, true)
                             .SingleOrDefault();

            if (attendance == null)
            {
                throw new Exception("Employee has either already clocked out or has not clocked in");
            }

            attendance.ClockOutTime = DateTime.Now;
            Update(attendance);
            SaveAsync();
        }

        //fetches attendance record for a particular employee
        public async Task<IEnumerable<Attendance>> GetAttendanceByEmployeeAsync(int employeeId)
        {
            return await FindByCondition(a => a.EmployeeId == employeeId).ToListAsync();
        }

        //fetches all attendance records for all employees for a particular date
        public async Task<IEnumerable<Attendance>> GetAttendanceByDateAsync(DateTime date, bool trackChanges) =>
            await FindByCondition(a => a.ClockInTime.Date == date.Date, trackChanges)
            .Include(a => a.Employee)
            .ToListAsync();

        //can filter and fetch specific employees' attendance history for a particular date
        public async Task<IEnumerable<Attendance>> GetAttendanceForEmployeesByDateAsync(DateTime date, IEnumerable<int> employeeIds = null, bool trackChanges = false)
        {
            var attendanceRecords = FindAll(trackChanges)
                .Where(a => a.ClockInTime.Date == date.Date);

            if (employeeIds != null && employeeIds.Any())
            {
                attendanceRecords = attendanceRecords.Where(a => employeeIds.Contains(a.EmployeeId));
            }

            return await attendanceRecords.ToListAsync();
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendanceAsync(bool trackChanges = false)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
    }
}
