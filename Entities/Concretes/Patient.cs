namespace Entities.Concretes;

public class Patient:Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsActive { get; set; }
    public List<Appointment>? Appointments { get; set; }
    public List<Invoice>? Invoices { get; set; }
    public List<Payment>? Payments { get; set; }
    public List<Treatment>? Treatments { get; set; }
}
