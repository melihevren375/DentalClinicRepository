namespace Entities.Exceptions.NotFoundExceptions;

public abstract class BaseNotFoundException : Exception
{
    public BaseNotFoundException(string message) : base(message)
    {

    }
}
