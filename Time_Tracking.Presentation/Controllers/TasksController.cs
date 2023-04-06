using Microsoft.AspNetCore.Mvc;
using Time_Tracking.BLL.Service.Manager;
using Time_Tracking.Shared.DataTransferObjects;

namespace Time_Tracking.Presentation.Controllers
{
    [Route("api/employees/{employeeId}")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly IServiceManager _service;
        public TasksController(IServiceManager service) => _service = service;

        [HttpGet("Tasks")]
        public async Task<IActionResult> GetTasksAsync()
        {
            var tasks = await _service.TodoService.GetAllTasksAsync(trackChanges: false);
            return Ok(tasks);
        }

        //{id:int}/{taskId:int}
        [HttpGet("TaskById", Name = "GetTaskForEmployee")]
        public async Task<IActionResult> GetTaskAsync(int id, int taskId)
        {
            var task = await _service.TodoService.GetTaskAsync(id, taskId, trackChanges: false);
            return Ok(task);
        }

        

    }
}
