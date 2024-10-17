using Entities.ValidationAttiributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.ClinicalAssistantDtos;

public record ClinicalAssistantDtoForRead:ClinicalAssistantDtoForManipulation
{
    [Required(ErrorMessage = "First Name is a required field. It cannot be empty.")]
    [StringLength(100,MinimumLength =2, ErrorMessage = "First Name cannot exceed 100 characters.")]
    public string FirstName { get; init; }

    [Required(ErrorMessage = "Last Name is a required field. It cannot be empty.")]
    [StringLength(100,MinimumLength =2, ErrorMessage = "Last Name cannot exceed 100 characters.")]
    public string LastName { get; init; }

    [Required(ErrorMessage = "Phone Number is a required field. It cannot be empty.")]
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string PhoneNumber { get; init; }

    [Required(ErrorMessage = "Date of Birth is a required field. It cannot be empty.")]
    [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
    public DateTime DateOfBirth { get; init; }

    [Required(ErrorMessage = "IsActive is a required field. It cannot be empty.")]
    public bool IsActive { get; init; }

    [Required(ErrorMessage = "Employee Type ID is a required field. It cannot be empty.")]
    public Guid EmployeeTypeId { get; init; }

    [StringLength(100, ErrorMessage = "Certification Number cannot exceed 100 characters.")]
    public string? CertificationNumber { get; init; }

    [StringLength(200, ErrorMessage = "Specialty Area cannot exceed 200 characters.")]
    public string? SpecialtyArea { get; init; }

    [Required(ErrorMessage = "CreatedDate is a required field. It cannot be empty.")]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime CreatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? UpdatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? DeletedDate { get; init; }
}
