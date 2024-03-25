namespace SQLiteSample.Maui.Datastore;

public class InstanceNotCreatedException : Exception
{
    public InstanceNotCreatedException() : base()
    {
    }

    public InstanceNotCreatedException(string message) : base(message)
    {
    }

    public InstanceNotCreatedException(string message, Exception innerException) : base(message, innerException)
    {
    }
}