namespace Time_Tracking.BLL.DTOs;

public class UserManagerResponse
{
    public string Message { get; set; }

    public bool IsSuccess { get; set; }

    public TodoDTO TodoDto { get; set; }

    public List<TodoDTO> TodoDtos { get; set; }
}