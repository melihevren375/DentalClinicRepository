namespace Entities.Exceptions.NotFoundExceptions;

public sealed class InvoiceNotFoundException:BaseNotFoundException
{
    public InvoiceNotFoundException(Guid id):
        base($"Invoice number {id} not found.")
    {
        
    }
}
