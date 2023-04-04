using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Tracking.DAL.Entities.Models
{
    public class Attendance : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public bool ClockedIn { get; set; }
        public bool ClockedOut { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime? ClockOutTime { get; set; }
    }
}
