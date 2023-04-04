using Microsoft.AspNetCore.Mvc;
using Time_Tracking.BLL.Service.Manager;
using Time_Tracking.Shared.DataTransferObjects;

namespace Time_Tracking.Presentation.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IServiceManager _service;
        public EmployeesController(IServiceManager service) => _service = service;

        [HttpPost("{employeeId}/clockin")]
        public IActionResult ClockIn(int employeeId)
        {
            var clockIn = _service.AttendanceService.ClockIn;
            return Ok(clockIn);
        }

        [HttpPost("{employeeId}/clockout")]
        public IActionResult ClockOut(int employeeId)
        {
            var clockOut = _service.AttendanceService.ClockOut;
            return Ok(clockOut);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync(int employeeId, [FromBody] CreatingTaskDTO task)
        {
            if (task is null)
                return BadRequest("CreatingTaskDTO object is null");
            var taskToReturn = await _service.TodoService.CreateTaskAsync(employeeId, task, trackChanges: false);
            return CreatedAtRoute("GetTaskForEmployee", new { employeeId, id = taskToReturn.EmployeeId }, taskToReturn);
        }
        
    }
}
