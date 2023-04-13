using System.ComponentModel.DataAnnotations;

namespace Time_Tracking.BLL.DTOs;

public class CreateTodoDTO
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(50, ErrorMessage = "Title length should be between 5 to 50 characters", MinimumLength = 5)]
    public string Title { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [StringLength(1000, ErrorMessage = "Description length should be between 20 to 1000 characters",
        MinimumLength = 20)]
    public string Description { get; set; }

    public DateTime DueAt { get; set; }

    [Required(ErrorMessage = "State is required and must be in the Todo State Enum")]
    public TodoStateDTO State { get; set; }

    [Required(ErrorMessage = "Priority is required and must be in the Priority Enum")]
    public PriorityDTO Priority { get; set; }

    public DateTime CreatedAt { get; set; }
}