using Microsoft.AspNetCore.Mvc;
using Time_Tracking.BLL.Service.Manager;
using Time_Tracking.Shared.DataTransferObjects;

namespace Time_Tracking.Presentation.Controllers;

[Route("api/admins")]
[ApiController]
public class AdminsController : Controller
{
    private readonly IServiceManager _service;
    public AdminsController(IServiceManager service) => _service = service;


    [HttpGet("Employees")]
    public async Task<IActionResult> GetEmployeesAsync()
    {
        var employees = await _service.EmployeeService.GetAllEmployeesAsync(trackChanges: false);
        return Ok(employees);
    }


    [HttpGet("EmployeeById", Name = "EmployeeById")]
    public async Task<IActionResult> GetEmployeeAsync(int employeeId)
    {
        var company = await _service.EmployeeService.GetEmployeeAsync(employeeId, trackChanges: false);
        return Ok(company);
    }


    [HttpPost("CreateEmployee")]
    public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreatingEmployeeDto employee)
    {
        var createdEmployee = await _service.EmployeeService.CreateEmployeeAsync(employee);
        return CreatedAtRoute("EmployeeById", new { name = createdEmployee.FullName }, createdEmployee);
    }

    //{id:id}
    [HttpPut("UpdateEmployeeProfile")]
    public async Task<IActionResult> UpdateEmployeeProfileAsync(int employeeId,
        [FromBody] UpdatingEmployeeDTO employee)
    {
        await _service.EmployeeService.UpdateEmployeeProfileAsync(employeeId, employee, trackChanges: true);
        return NoContent();
    }

    //{id:guid}
    [HttpDelete("DeleteEmployee")]
    public async Task<IActionResult> DeleteEmployeeAsync(int employeeId)
    {
        await _service.EmployeeService.DeleteEmployeeAsync(employeeId, trackChanges: false);
        return NoContent();
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
}