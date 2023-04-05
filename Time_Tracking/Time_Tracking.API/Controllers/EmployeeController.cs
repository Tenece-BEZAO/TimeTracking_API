using Microsoft.AspNetCore.Mvc;
using Time_Tracking.BLL.DTOs;
using Time_Tracking.BLL.Interfaces;
using Time_Tracking.DAL.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using static Time_Tracking.DAL.ExceptionHandling.Exceptions.Response;

namespace Time_Tracking.API.Controllers
{
    [ApiController]
    [Route("api")]
    [SwaggerTag("Employee Operations")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }





        [HttpPost("{employeeId}/clockin")]
        [SwaggerOperation(Summary = "Clocks in an employee")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Employee successfully clocked in", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid employee ID", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Internal server error", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> ClockIn(string employeeId)
        {
            var message = await _employeeService.ClockInAsync(employeeId);
            return Ok(message);
        }



        [HttpPost("{employeeId}/clockout")]
        [SwaggerOperation(Summary = "Clocks out an employee")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Employee successfully clocked out", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid employee ID", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Internal server error", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> ClockOut(string employeeId)
        {
            var message = await _employeeService.ClockOutAsync(employeeId);
            return Ok(message);
        }





        [HttpPost("{employeeId}/CreateTodos")]
        [SwaggerOperation(Summary = "Creates Todo By Employee")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Employee successfully created a Todo", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Unable to Create Todo", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Internal server error", Type = typeof(ErrorResponse))]
        public async Task<ActionResult<UserManagerResponse>> CreateTask(string employeeId, [FromBody] TodoDTO todoDto)
        {
            var response = await _employeeService.CreateTaskAsync(employeeId, todoDto);
            return Ok(response);
        }







        [HttpPost("{employeeId}/todos/{todoId}/start")]
        [SwaggerOperation(Summary = "Employee Starts a Todo for the day")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Employee successfully started a Todo", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid employee or Todo ID", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Internal server error", Type = typeof(ErrorResponse))]
        public async Task<ActionResult<UserManagerResponse>> StartTask(string employeeId, int todoId)
        {
            var response = await _employeeService.StartTaskAsync(employeeId, todoId);
            return Ok(response);
        }






        [HttpGet("{employeeId}/todos/dailySummary")]
        [SwaggerOperation(Summary = "Get Todo Summary for the day")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Employee successfully got Todo Summary", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid employee  ID", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Internal server error", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetDailySummary(string employeeId)
        {
            var todoDtos = await _employeeService.GetDailySummaryAsync(employeeId);
            return Ok(todoDtos);
        }




        [HttpGet("{employeeId}/todos/importPendingTodos")]
        [SwaggerOperation(Summary = "Import Pending Todos")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Employee successfully imported Pending Todos", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid employee  ID", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Internal server error", Type = typeof(ErrorResponse))]
        public async Task<IActionResult> ImportPendingTasks(string employeeId)
        {
            var pendingTodos = await _employeeService.ImportPendingTasksAsync(employeeId);
            return Ok(pendingTodos);
        }




        [HttpPost("{employeeId}/todos/stop")]
        [SwaggerOperation(Summary = "Stop Todos in Progress")]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Employee successfully Paused Todos in Progress", Type = typeof(SuccessResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Invalid employee  ID", Type = typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "Internal server error", Type = typeof(ErrorResponse))]
        public async Task<ActionResult<UserManagerResponse>> StopTask(string employeeId, int TodoId)
        {
            var response = await _employeeService.StopTaskAsync(employeeId, TodoId);
            return Ok(response);
        }
    }
}
