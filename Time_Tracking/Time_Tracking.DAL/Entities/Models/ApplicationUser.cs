using Microsoft.AspNetCore.Identity;

namespace Time_Tracking.DAL.Entities.Models
{
    public class ApplicationUser : IdentityUser
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
