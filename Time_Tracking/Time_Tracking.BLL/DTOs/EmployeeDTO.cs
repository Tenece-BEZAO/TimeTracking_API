using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Tracking.BLL.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(50, ErrorMessage = "FirstName length should be between 5 to 50 characters", MinimumLength = 5)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [StringLength(50, ErrorMessage = "LastName length should be between 5 to 50 characters", MinimumLength = 5)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [StringLength(50, ErrorMessage = "Department length should be between 5 to 50 characters", MinimumLength = 5)]
        public string Department { get; set; }
    }

}
