namespace Time_Tracking.BLL.DTOs;

public enum Priority
{
    Low,
    Normal,
    High
}

public class PriorityDTO
{
    public PriorityDTO(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}