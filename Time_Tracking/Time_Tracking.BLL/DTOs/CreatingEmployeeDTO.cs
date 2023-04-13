namespace Time_Tracking.Shared.DataTransferObjects;

public record CreatingEmployeeDto(string FullName, string PhoneNumber, string Email, string Password,
    string Department);