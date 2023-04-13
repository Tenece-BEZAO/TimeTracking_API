namespace Time_Tracking.DAL.Entities.Exceptions
{
    public sealed class TasksNotFoundException : NotFoundException
    {
        public TasksNotFoundException() : base($"No task(s) found in the database.")
        { }
    }
}
