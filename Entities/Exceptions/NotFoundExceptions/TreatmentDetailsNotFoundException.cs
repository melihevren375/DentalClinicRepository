namespace Entities.Exceptions.NotFoundExceptions;

public sealed class TreatmentDetailsNotFoundException : BaseNotFoundException
{
    public TreatmentDetailsNotFoundException(Guid id) :
        base($"Treatment number {id} not found.")
    {

    }
}
