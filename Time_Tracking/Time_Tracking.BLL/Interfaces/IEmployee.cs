using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_Tracking.BLL.DTOs;
using Time_Tracking.DAL.DTOs;
using Time_Tracking.DAL.Entities;
using Time_Tracking.DAL.Interfaces;

namespace Time_Tracking.BLL.Interfaces
{
  
    public interface IEmployeeService 
    
    {

        Task<string> ClockInAsync(string employeeId);
        Task<string> ClockOutAsync(string employeeId);

        Task<UserManagerResponse> CreateTaskAsync(string employeeId, TodoDTO todoDto);
        Task<UserManagerResponse> StartTaskAsync(string employeeId, int todoId);
        Task<UserManagerResponse> StopTaskAsync(string employeeId, int TodoId);
        Task<IEnumerable<TodoDTO>> GetDailySummaryAsync(string employeeId);
        

        Task<UserManagerResponse> ImportPendingTasksAsync(string employeeId);



    }

  



}
