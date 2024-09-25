namespace Entities.Concretes;

public class Payment:Entity
{
    public Guid InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public Guid PaymentMethodId { get; set; }
    public string? Notes { get; set; }
    public Invoice Invoice { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}
