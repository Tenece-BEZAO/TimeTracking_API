using Microsoft.AspNetCore.Mvc;
using Time_Tracking.BLL.Service.Manager;
using Time_Tracking.Shared.DataTransferObjects;

namespace Time_Tracking.Presentation.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminsController : Controller
    {
        private readonly IServiceManager _service;
        public AdminsController(IServiceManager service) => _service = service;  


        [HttpGet]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var employees = await _service.EmployeeService.GetAllEmployeesAsync(trackChanges: false);
            return Ok(employees);
        }


        [HttpGet("{id:int}", Name = "EmployeeById")]
        public async Task<IActionResult> GetEmployeeAsync(int employeeId)
        {
            var company = await _service.EmployeeService.GetEmployeeAsync(employeeId, trackChanges: false);
            return Ok(company);
        }


        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreatingEmployeeDTO employee)
        {
            if (employee is null)
                return BadRequest("CreatingEmployeeDTO object is null");
            var createdEmployee = await _service.EmployeeService.CreateEmployeeAsync(employee);
            return CreatedAtRoute("EmployeeById", new { name = createdEmployee.FullName }, createdEmployee);
        }


        [HttpGet("AllAttendanceHistory")]
        public async Task<IActionResult> GetAllAttendanceAsync()
        {
            var attendance = await _service.AttendanceService.GetAllAttendanceAsync(trackChanges: false);
            return Ok(attendance);
        }


        [HttpGet("AttendanceById")]
        public async Task<IActionResult> GetAttendanceByEmployeeAsync(int employeeId)
        {
            var attendance = await _service.AttendanceService.GetAttendanceByEmployeeAsync(employeeId);
            return Ok(attendance);
        }


        [HttpGet("AllAttendanceByDate")]
        public async Task<IActionResult> GetAttendanceByDateAsync(DateTime date, bool trackChanges)
        {
            var attendance = await _service.AttendanceService.GetAttendanceByDateAsync(date, trackChanges: false);
            return Ok(attendance);
        }


        [HttpGet("FilterEmployeesAttendanceByDate")]
        public async Task<IActionResult> GetAttendanceForEmployeesByDateAsync(DateTime date, IEnumerable<int> employeeIds, bool trackChanges)
        {
            var attendance = await _service.AttendanceService.GetAttendanceForEmployeesByDateAsync(date, employeeIds, trackChanges: false);
            return Ok(attendance);
        }
 
    }
}
