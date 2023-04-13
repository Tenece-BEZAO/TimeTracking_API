namespace Time_Tracking.DAL.ExceptionHandling.Exceptions;

public abstract class BadRequestException : Exception
{
    protected BadRequestException(string message)
        : base(message)
    {
    }
}