namespace Time_Tracking.DAL.Entities.Exceptions
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message)
        : base(message)
        { }
    }
}
