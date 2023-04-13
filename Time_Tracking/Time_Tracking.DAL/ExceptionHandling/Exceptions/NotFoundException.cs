namespace Time_Tracking.DAL.Implementations.EmployeeExtension
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string entityName, object entityId)
            : base($"Entity {entityName} with ID {entityId} was not found.")
        {
        }


    }
}

