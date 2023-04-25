using Time_Tracking.BLL.DTOs;

namespace Time_Tracking.BLL.Service.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync(bool trackChanges);
    Task<EmployeeDTO> GetEmployeeAsync(int employeeId, bool trackChanges);
    Task<EmployeeDTO> CreateEmployeeAsync(CreatingEmployeeDto employee);
    Task DeleteEmployeeAsync(int employeeId, bool trackChanges);
    Task UpdateEmployeeProfileAsync(int employeeId, UpdatingEmployeeDTO employeeToUpdate, bool trackChanges);
}