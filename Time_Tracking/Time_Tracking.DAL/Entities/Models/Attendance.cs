using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Tracking.DAL.Entities
{
   

    public class Attendance : BaseEntity
    {
        public int EmployeeId { get; set; } 
        public Employee Employee { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime? ClockOut { get; set; }
        public bool IsAdminOverride { get; set; } // set to true if the admin manually clocked the employee in/out
    }

}
