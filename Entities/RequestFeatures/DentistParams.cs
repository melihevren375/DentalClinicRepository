namespace Entities.RequestFeatures;

public class DentistParams:RequestParams
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? MaxBirthDate { get; set; }
    public DateTime? MinBirthDate { get; set; }
    public bool? IsActive { get; set; }
    public string? Specialty { get; set; }
}
