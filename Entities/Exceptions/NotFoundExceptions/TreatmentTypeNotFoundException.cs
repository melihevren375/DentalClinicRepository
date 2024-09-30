namespace Entities.Exceptions.NotFoundExceptions;

public sealed class TreatmentTypeNotFoundException : BaseNotFoundException
{
    public TreatmentTypeNotFoundException(Guid id) :
        base($"TreatmentType number {id} not found.")
    {

    }
}
