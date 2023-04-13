using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Tracking.DAL.Entities.Exceptions;

public sealed class UpdatingEmployeeBadRequestException : BadRequestException
{
    public UpdatingEmployeeBadRequestException() : base("UpdatingEmployeeDTO object is null")
    {
    }
}