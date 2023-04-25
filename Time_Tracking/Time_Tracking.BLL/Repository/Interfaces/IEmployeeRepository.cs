using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.BLL.Repository.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee> GetEmployeeAsync(int employeeId, bool trackChanges);
    Task<List<Employee>> GetAllEmployeesAsync(bool trackChanges);
    Task CreateEmployeeAsync(Employee employeeEntity);
    Task DeleteEmployeeAsync(Employee employeeEntity);
}