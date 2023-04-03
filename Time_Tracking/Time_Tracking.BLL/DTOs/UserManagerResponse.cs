using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_Tracking.BLL.DTOs;
using Time_Tracking.DAL.Entities;

namespace Time_Tracking.DAL.DTOs
{
    public class UserManagerResponse
    {

        public string Message { get; set; }

        public bool IsSuccess { get; set; }
       

        public TodoDTO TodoDto { get; set; }

        public List<TodoDTO> TodoDtos { get; set; }
    }
}
