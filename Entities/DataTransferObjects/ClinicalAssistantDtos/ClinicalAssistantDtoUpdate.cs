using Entities.ValidationAttiributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.ClinicalAssistantDtos;

public record ClinicalAssistantDtoUpdate:ClinicalAssistantDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; }

    [StringLength(100, ErrorMessage = "First Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "FirstName must contain only letters.")]
    public string? FirstName { get; init; }

    [StringLength(100, ErrorMessage = "Last Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "LastName must contain only letters.")]
    public string? LastName { get; init; }

    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string? PhoneNumber { get; init; }

    [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
    [PastDate]
    public DateTime? DateOfBirth { get; init; }

    public bool? IsActive { get; init; }

    public Guid? EmployeeTypeId { get; init; }

    [StringLength(100, ErrorMessage = "Certification Number cannot exceed 100 characters.")]
    public string? CertificationNumber { get; init; }

    [StringLength(200, ErrorMessage = "Specialty Area cannot exceed 200 characters.")]
    public string? SpecialtyArea { get; init; }

    [JsonIgnore]
    [Required(ErrorMessage = "UpdatedDate is a required field. It cannot be empty.")]
    public DateTime UpdatedDate { get; init; }
}
