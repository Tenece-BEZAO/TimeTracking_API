namespace Time_Tracking.Shared.DataTransferObjects
{
    public record AttendanceDTO(int EmployeeId, bool ClockedIn, bool ClockedOut, DateTime ClockInTime, DateTime ClockOutTime);
}
