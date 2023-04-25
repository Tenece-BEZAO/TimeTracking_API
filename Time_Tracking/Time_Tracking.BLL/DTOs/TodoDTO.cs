namespace Time_Tracking.BLL.DTOs;

public class TodoDTO : CreateTodoDTO
{
    public int Id { get; set; }

    public TodoDTO(string title, string description, DateTime dueAt, TodoStateDTO state, PriorityDTO priority,
        DateTime createdAt) : base(title, description, dueAt, state, priority, createdAt)
    {
    }
}