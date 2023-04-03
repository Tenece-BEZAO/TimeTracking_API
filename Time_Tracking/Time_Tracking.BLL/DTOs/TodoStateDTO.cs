using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Tracking.BLL.DTOs
{
    public enum TodoState
    {

        NotStarted,
        InProgress,
        Paused,
        Completed,
        TimeElapsedAndStillPending
    }


    public class TodoStateDTO
    {
        public string Name { get; set; }
    }
}
