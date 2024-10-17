namespace Entities.Concretes;

public class Invoice:Entity
{
    public Guid PatientId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime IssueDate { get; set; }
    public bool IsPaid { get; set; }
    public string? Notes { get; set; }
    public Patient Patient { get; set; }
    public List<Payment> Payments { get; set; }
}
