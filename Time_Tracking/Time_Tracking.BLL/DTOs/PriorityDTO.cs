using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Tracking.BLL.DTOs
{
    public enum Priority
    {
        Low,
        Normal,
        High
    }

    public class PriorityDTO
    {
        public string Name { get; set; }
    }

}
