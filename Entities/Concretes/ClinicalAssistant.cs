namespace Entities.Concretes;

public class ClinicalAssistant : Employee
{
    public string? CertificationNumber { get; set; }

    public string? SpecialtyArea { get; set; }

    public EmployeeType EmployeeType { get; set; }

}
