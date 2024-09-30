using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.PatientDtos;

public record PatientDtoForUpdate : PatientDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; }

    [StringLength(100, ErrorMessage = "First Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "FirstName must contain only letters.")]
    public string? FirstName { get; init; }

    [StringLength(100, ErrorMessage = "Last Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "FirstName must contain only letters.")]
    public string? LastName { get; init; }

    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string? PhoneNumber { get; init; }

    [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
    public DateTime? DateOfBirth { get; init; }

    public bool? IsActive { get; init; }

    [Required(ErrorMessage = "UpdatedDate is a required field. It cannot be empty.")]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime UpdatedDate { get; init; }

}
