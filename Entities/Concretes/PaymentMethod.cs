namespace Entities.Concretes;

public class PaymentMethod:Entity
{
    public string Name { get; set; }
    public List<Payment>? Payments { get; set; }
}
