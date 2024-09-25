namespace Entities.Concretes;

public class Treatment:Entity
{
    public Guid AppointmentId { get; set; }
    public decimal TotalAmount { get; set; }
    public Guid PatientId { get; set; }
    public Guid DentistId { get; set; }
    public Appointment Appointment { get; set; }
    public Patient Patient { get; set; }
    public Dentist Dentist { get; set; }
    public List<TreatmentDetails> TreatmentDetails { get; set; }
}
