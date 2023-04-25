namespace Time_Tracking.BLL.DTOs;

public class AttendanceDTO
{
    public AttendanceDTO(string employeeId)
    {
        EmployeeId = employeeId;
    }

    
    public string EmployeeId { get; set; }
    public DateTime ClockIn { get; set; }
    public DateTime? ClockOut { get; set; }
    public bool IsAdminOverride { get; set; }
}