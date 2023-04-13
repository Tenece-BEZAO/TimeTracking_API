namespace Time_Tracking.DAL.Entities.Models;

public class Employee : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Department { get; set; }
    public virtual ApplicationUser User { get; set; }
    public string UserId { get; set; }
    public ICollection<Attendance> Attendance { get; set; }
    public ICollection<Todo> Todos { get; set; }
    public int AdminId { get; set; }
    public Admin Admin { get; }
}