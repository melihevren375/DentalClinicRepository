namespace Entities.Concretes;

public class TreatmentType : Entity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public TreatmentDetails TreatmentDetail { get; set; }
}
