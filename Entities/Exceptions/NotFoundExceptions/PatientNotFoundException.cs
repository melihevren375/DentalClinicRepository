namespace Entities.Exceptions.NotFoundExceptions;

public sealed class PatientNotFoundException : BaseNotFoundException
{
    public PatientNotFoundException(Guid id) :
        base($"Patient number {id} not found.")
    {

    }
}
