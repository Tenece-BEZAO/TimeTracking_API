using Time_Tracking.BLL.DTOs;
using Time_Tracking.DAL.DTOs;

namespace Time_Tracking.BLL.Interfaces
{

    public interface IEmployeeService

    {

        Task<string> ClockInAsync(string employeeId);
        Task<string> ClockOutAsync(string employeeId);

        Task<UserManagerResponse> CreateTaskAsync(string employeeId, CreateTodoDTO createTodoDto);
        Task<UserManagerResponse> StartTaskAsync(string employeeId, int todoId);
        Task<UserManagerResponse> StopTaskAsync(string employeeId, int TodoId);
        Task<IEnumerable<TodoDTO>> GetDailySummaryAsync(string employeeId);


        Task<UserManagerResponse> ImportPendingTasksAsync(string employeeId);



    }





}
