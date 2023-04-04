using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Tracking.Shared.DataTransferObjects
{
    public record GetTaskCollectionRequestDTO(IEnumerable<int> employeeIds, IEnumerable<int> taskIds);
    
}
