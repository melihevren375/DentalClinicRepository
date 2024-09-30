namespace Entities.Exceptions.NotFoundExceptions;

public sealed class PaymentNotFoundException : BaseNotFoundException
{
    public PaymentNotFoundException(Guid id) :
        base($"Payment number {id} not found.")
    {

    }
}
