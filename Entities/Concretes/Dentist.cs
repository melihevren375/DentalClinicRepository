namespace Entities.Concretes;

public class Dentist:Employee
{
    public string LicenseNumber { get; set; }
    public string? Specialty { get; set; }
    public List<Appointment>? Appointments { get; set; }
    public List<Treatment>? Treatments { get; set; }
}
