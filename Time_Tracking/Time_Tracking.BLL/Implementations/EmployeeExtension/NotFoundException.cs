using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Tracking.BLL.Implementations.EmployeeExtension
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string entityName, object entityId)
            : base($"Entity {entityName} with ID {entityId} was not found.")
        {
        }
    }
}

