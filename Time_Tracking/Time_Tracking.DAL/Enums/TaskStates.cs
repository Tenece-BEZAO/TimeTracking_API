using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Tracking.DAL.Enums
{
    public enum State
    {
        NotStarted,
        InProgress,
        Paused,
        Completed,
        TimeElapsedAndStillPending
    }

   
}
