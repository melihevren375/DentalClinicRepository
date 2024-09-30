namespace Entities.Exceptions.NotFoundExceptions;

public sealed class TreatmentNotFoundException : BaseNotFoundException
{
    public TreatmentNotFoundException(Guid id) :
        base($"Treatment number {id} not found.")
    {

    }
}
