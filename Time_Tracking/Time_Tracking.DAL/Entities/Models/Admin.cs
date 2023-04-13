namespace Time_Tracking.DAL.Entities.Models
{
    public class Admin : BaseEntity
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<Entities.Employee>? Employees { get; set; }
    }
}
