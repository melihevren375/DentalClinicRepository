namespace Entities.Exceptions.NotFoundExceptions;

public sealed class DentistNotFoundException : BaseNotFoundException
{
    public DentistNotFoundException(Guid id) :
        base($"Dentist number {id} not found")
    {

    }
}
