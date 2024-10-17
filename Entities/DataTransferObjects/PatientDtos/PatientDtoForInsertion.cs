using Entities.ValidationAttiributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.PatientDtos;

public record PatientDtoForInsertion:PatientDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; }

    [Required(ErrorMessage = "First Name is a required field. It cannot be empty.")]
    [StringLength(100,MinimumLength =2 ,ErrorMessage = "First Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "FirstName must contain only letters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "LastName is a required field. It cannot be empty.")]
    [StringLength(100,MinimumLength =2, ErrorMessage = "LastName cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "LastName must contain only letters.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Phone Number is a required field. It cannot be empty.")]
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string PhoneNumber { get; init; }

    [Required(ErrorMessage = "Date of Birth is a required field. It cannot be empty.")]
    [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
    [PastDate]
    public DateTime DateOfBirth { get; init; }

    [Required(ErrorMessage = "IsActive is a required field. It cannot be empty.")]
    public bool IsActive { get; init; }

    [JsonIgnore]
    public DateTime CreatedDate { get; init; }
}
