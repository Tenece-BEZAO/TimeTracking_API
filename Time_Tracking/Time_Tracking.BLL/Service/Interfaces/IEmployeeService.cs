using Time_Tracking.Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Time_Tracking.BLL.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync(bool trackChanges);
        Task<IEnumerable<EmployeeDTO>> GetEmployeesByIdsAsync(IEnumerable<int> employeeIds, bool trackChanges);
        Task<EmployeeDTO> GetEmployeeAsync(int employeeId, bool trackChanges);
        Task<EmployeeDTO> CreateEmployeeAsync(CreatingEmployeeDTO employee);
    }
}
