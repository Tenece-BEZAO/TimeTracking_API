using Microsoft.AspNetCore.Mvc;
using Time_Tracking.BLL.DTOs;
using Time_Tracking.BLL.Implementations;
using Time_Tracking.BLL.Interfaces;
using Time_Tracking.DAL.DTOs;

namespace Time_Tracking.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }





        [HttpPost("{employeeId}/clockin")]
        public async Task<IActionResult> ClockIn(string employeeId)
        {
            var message = await _employeeService.ClockInAsync(employeeId);
            return Ok(message);
        }

        [HttpPost("{employeeId}/clockout")]
        public async Task<IActionResult> ClockOut(string employeeId)
        {
             var message = await _employeeService.ClockOutAsync(employeeId);
            return Ok(message);
        }

      

        [HttpPost("{employeeId}/CreateTodos")]
        public async Task<ActionResult<UserManagerResponse>> CreateTask(string employeeId, [FromBody] TodoDTO todoDto)
        {
            var response = await _employeeService.CreateTaskAsync(employeeId, todoDto);
            return Ok(response);
        }





        [HttpPost("{employeeId}/todos/{todoId}/start")]
        public async Task<ActionResult<UserManagerResponse>> StartTask(string employeeId, int todoId)
        {
            var response = await _employeeService.StartTaskAsync(employeeId, todoId);
            return Ok(response);
        }




        [HttpGet("{employeeId}/todos/daily")]
        public async Task<IActionResult> GetDailySummary(string employeeId)
        {
            var todoDtos = await _employeeService.GetDailySummaryAsync(employeeId);
            return Ok(todoDtos);
        }

        [HttpGet("{employeeId}/todos/import")]
        public async Task<IActionResult> ImportPendingTasks(string employeeId)
        {
            var pendingTodos = await _employeeService.ImportPendingTasksAsync(employeeId);
            return Ok(pendingTodos);
        }

        [HttpPost("{employeeId}/todos/stop")]
        public async Task<ActionResult<UserManagerResponse>> StopTask(string employeeId, int TodoId)
        {
            var response = await _employeeService.StopTaskAsync(employeeId, TodoId);
            return Ok(response);
        }
    }
}
