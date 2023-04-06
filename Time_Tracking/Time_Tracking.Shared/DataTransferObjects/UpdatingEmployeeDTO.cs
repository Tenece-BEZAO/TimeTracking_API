using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Tracking.Shared.DataTransferObjects
{
    
    public record UpdatingEmployeeDTO(string FullName, string PhoneNumber, string Email, string Password, string Department);
}
