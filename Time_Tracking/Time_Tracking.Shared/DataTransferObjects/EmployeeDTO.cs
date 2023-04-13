using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.Shared.DataTransferObjects
{
    public record EmployeeDTO(string FullName, string PhoneNumber, string Email, string Department, IList<Todo>? Tasks);
}
