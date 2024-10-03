namespace Entities.RequestFeatures;

public class TreatmentParams : RequestParams
{
    public decimal? MinTotalAmount { get; set; }
    public decimal? MaxTotalAmount { get; set; }
    public Guid? PatientId { get; set; }
    public Guid? DentistId { get; set; }
    public Guid? AppointmentId { get; set; } 
}
