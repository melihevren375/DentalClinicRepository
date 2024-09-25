namespace Entities.Concretes;

public class Appointment : Entity
{
    public Guid PatientId { get; set; }
    public Guid DentistId { get; set; }
    public DateTime DateOfAppointment { get; set; }
    public string? Notes { get; set; }
    public bool IsActive { get; set; }
    public Patient Patient { get; set; }
    public Dentist Dentist { get; set; }
    public List<Treatment>? Treatments { get; set; }
}
