namespace Time_Tracking.DAL.Entities.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message)
        : base(message)
        { }
    }
}
