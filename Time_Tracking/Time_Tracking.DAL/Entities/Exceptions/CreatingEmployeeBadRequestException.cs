namespace Time_Tracking.DAL.Entities.Exceptions;

public sealed class CreatingEmployeeBadRequestException : BadRequestException
{
    public CreatingEmployeeBadRequestException() : base("CreatingEmployeeDTO object is null")
    {
    }
}