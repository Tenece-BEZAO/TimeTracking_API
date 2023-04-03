using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_Tracking.DAL.Enums;

namespace Time_Tracking.BLL.DTOs
{
    public class TodoDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueAt { get; set; }
        public TodoStateDTO State { get; set; }
        public PriorityDTO Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }







}
