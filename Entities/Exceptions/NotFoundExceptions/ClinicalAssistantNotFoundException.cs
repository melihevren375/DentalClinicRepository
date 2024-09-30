namespace Entities.Exceptions.NotFoundExceptions;

public sealed class ClinicalAssistantNotFoundException : BaseNotFoundException
{
    public ClinicalAssistantNotFoundException(Guid id) :
        base($"ClinicalAssistant number {id} not found")
    {

    }
}
