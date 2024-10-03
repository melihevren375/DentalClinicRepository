namespace Entities.RequestFeatures;

public class PatientParams:RequestParams
{
    public string? FirstNameContains { get; set; } 
    public string? LastNameContains { get; set; } 
    public string? PhoneNumberContains { get; set; } 
    public DateTime? MinDateOfBirth { get; set; } 
    public DateTime? MaxDateOfBirth { get; set; } 
    public bool? IsActive { get; set; } 
}
