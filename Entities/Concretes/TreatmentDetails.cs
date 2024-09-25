namespace Entities.Concretes;

public class TreatmentDetails:Entity
{
    public Guid TreatmentId { get; set; }
    public Guid TreatmentTypeId { get; set; }
    public int? ToothNumber { get; set; }
    public string? Notes { get; set; }
    public bool IsCompleted { get; set; }
    public Treatment Treatment { get; set; }
    public TreatmentType TreatmentType { get; set; }
}
