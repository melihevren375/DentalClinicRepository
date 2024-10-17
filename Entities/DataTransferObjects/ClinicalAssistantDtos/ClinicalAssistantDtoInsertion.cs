using Entities.ValidationAttiributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.ClinicalAssistantDtos;

public record ClinicalAssistantDtoInsertion : ClinicalAssistantDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; } 

    [Required(ErrorMessage = "First Name is a required field. It cannot be empty.")]
    [StringLength(100,MinimumLength =2, ErrorMessage = "First Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "FirstName must contain only letters.")]
    public string FirstName { get; init; }

    [Required(ErrorMessage = "Last Name is a required field. It cannot be empty.")]
    [StringLength(100,MinimumLength =2, ErrorMessage = "Last Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "LastName must contain only letters.")]
    public string LastName { get; init; }

    [Required(ErrorMessage = "Phone Number is a required field. It cannot be empty.")]
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string PhoneNumber { get; init; }

    [Required(ErrorMessage = "Date of Birth is a required field. It cannot be empty.")]
    [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
    [PastDate]
    public DateTime DateOfBirth { get; init; }

    [Required(ErrorMessage = "IsActive is a required field. It cannot be empty.")]
    public bool IsActive { get; init; }

    [Required(ErrorMessage = "Employee Type ID is a required field. It cannot be empty.")]
    public Guid EmployeeTypeId { get; init; }

    [StringLength(100, ErrorMessage = "Certification Number cannot exceed 100 characters.")]
    public string? CertificationNumber { get; init; }

    [StringLength(200, ErrorMessage = "Specialty Area cannot exceed 200 characters.")]
    public string? SpecialtyArea { get; init; }

    [JsonIgnore]
    public DateTime CreatedDate { get; init; }
}
