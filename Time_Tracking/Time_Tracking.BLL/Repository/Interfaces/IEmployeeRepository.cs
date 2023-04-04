using Time_Tracking.DAL.Entities.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Time_Tracking.BLL.Repository.Interfaces
{
    public interface IEmployeeRepository
    {      
        Task<Employee> GetEmployeeAsync(int employeeId, bool trackChanges);
        Task<IEnumerable<Employee>> GetEmployeesByIdsAsync(IEnumerable<int> employeeIds, bool trackChanges);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync(bool trackChanges);
        Task CreateEmployeeAsync(Employee employeeEntity);
        
    }
}
