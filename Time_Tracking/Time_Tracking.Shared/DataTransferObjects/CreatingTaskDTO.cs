using Time_Tracking.DAL.Enums;

namespace Time_Tracking.Shared.DataTransferObjects
{
    public record CreatingTaskDTO(string Title, string Description, DateTime DueAt, State State, Priority Priority, int EmployeeId);
}
