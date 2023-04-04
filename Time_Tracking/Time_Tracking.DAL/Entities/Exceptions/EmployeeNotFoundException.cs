namespace Time_Tracking.DAL.Entities.Exceptions
{
    public sealed class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(int employeeId) : base($"The employee with id: {employeeId} doesn't exist in the database.")
        { }
    }
}
