using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.Shared.DataTransferObjects
{
    public record CreatingEmployeeDTO(string FullName, string PhoneNumber, string Email, string Password, string ConfirmPassword, string Department, IList<Todo>? Tasks);
}
