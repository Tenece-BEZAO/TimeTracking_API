using Microsoft.AspNetCore.Mvc;
using Time_Tracking.BLL.Service.Manager;
using Time_Tracking.Shared.DataTransferObjects;

namespace Time_Tracking.Presentation.Controllers
{
    [Route("api/employees/{employeeId}/tasks")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly IServiceManager _service;
        public TasksController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetTasksAsync()
        {
            var tasks = await _service.TodoService.GetAllTasksAsync(trackChanges: false);
            return Ok(tasks);
        }

        [HttpGet("{id:int}/{taskId:int}", Name = "GetTaskForEmployee")]
        public async Task<IActionResult> GetTaskAsync(int id, int taskId)
        {
            var task = await _service.TodoService.GetTaskAsync(id, taskId, trackChanges: false);
            return Ok(task);
        }
        //to be removed
        [HttpGet("collection", Name = "TaskCollection")]
        public async Task<IActionResult> GetTaskCollectionAsync([FromBody] GetTaskCollectionRequestDTO request)
        {
            var tasks = await _service.TodoService.GetTasksByIdsAsync(request, trackChanges: false);
            return Ok(tasks);
        }

    }
}
