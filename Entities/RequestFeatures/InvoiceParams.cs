using Entities.Concretes;

namespace Entities.RequestFeatures;

public class InvoiceParams:RequestParams
{
    public DateTime? MinIssueDate { get; set; } 
    public DateTime? MaxIssueDate { get; set; } 
    public decimal? MinTotalAmount { get; set; } 
    public decimal? MaxTotalAmount { get; set; } 
    public bool? IsPaid { get; set; } 
    public string? NotesContains { get; set; } 
}
