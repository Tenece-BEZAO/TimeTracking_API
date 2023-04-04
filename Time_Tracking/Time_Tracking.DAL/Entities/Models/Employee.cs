namespace Time_Tracking.DAL.Entities.Models
{
    public class Employee : BaseEntity
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public IList<Todo>? Tasks { get; set; }
        public IList<Attendance> AttendanceHistory { get; set; }
    }
}
