namespace Entities.Exceptions.NotFoundExceptions;

public sealed class ReceptionistNotFoundException : BaseNotFoundException
{
    public ReceptionistNotFoundException(Guid id) :
        base($"Receptionist number {id} not found.")
    {

    }
}
