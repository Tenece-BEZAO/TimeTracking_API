using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.BLL.Repository.Interfaces
{
    public interface IAttendanceRepository
    {
        void ClockIn(int employeeId);
        void ClockOut(int employeeId);
        Task<IEnumerable<Attendance>> GetAttendanceByEmployeeAsync(int employeeId);
        Task<IEnumerable<Attendance>> GetAttendanceByDateAsync(DateTime date, bool trackChanges);
        Task<IEnumerable<Attendance>> GetAttendanceForEmployeesByDateAsync(DateTime date, IEnumerable<int> employeeIds, bool trackChanges);
        Task<IEnumerable<Attendance>> GetAllAttendanceAsync(bool trackChanges);
        
    }
}
