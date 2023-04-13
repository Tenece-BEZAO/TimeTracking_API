namespace Time_Tracking.BLL.DTOs;

public record UpdatingEmployeeDTO(string FullName, string PhoneNumber, string Email, string Password,
    string Department);