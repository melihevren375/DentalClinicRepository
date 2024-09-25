namespace Entities.Concretes;

public class EmployeeType:Entity
{
    public string Name { get; set; }
    public List<Employee>? Employees { get; set; }
}
