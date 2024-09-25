namespace Entities.Concretes;

public abstract class Employee:Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsActive { get; set; }
    public Guid EmployeeTypeId { get; set; }
}
