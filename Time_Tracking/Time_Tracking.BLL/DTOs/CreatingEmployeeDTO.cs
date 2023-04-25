namespace Time_Tracking.BLL.DTOs;

public record CreatingEmployeeDto(string FullName, string PhoneNumber, string Email, string Password,
    string Department);