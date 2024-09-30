namespace Entities.Exceptions.NotFoundExceptions;

public sealed class PaymentMethodNotFoundExpcetion:BaseNotFoundException
{
    public PaymentMethodNotFoundExpcetion(Guid id) :
        base($"Payment number {id} not found.")
    {

    }
}
