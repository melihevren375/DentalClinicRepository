namespace Entities.RequestFeatures;

public class PaymentParams:RequestParams
{
    public DateTime? MinPaymentDate { get; set; } 
    public DateTime? MaxPaymentDate { get; set; } 
    public decimal? MinAmount { get; set; } 
    public decimal? MaxAmount { get; set; } 
    public Guid? PaymentMethodId { get; set; } 
    public Guid? InvoiceId { get; set; } 
    public string? NotesContains { get; set; } 
}
