using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.PatientDtos;

public record PatientDtoForRead:PatientDtoForManipulation
{
    [Required(ErrorMessage = "First Name is a required field. It cannot be empty.")]
    [StringLength(100, ErrorMessage = "First Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "FirstName must contain only letters.")]
    public string FirstName { get; init; }

    [Required(ErrorMessage = "Last Name is a required field. It cannot be empty.")]
    [StringLength(100, ErrorMessage = "Last Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "FirstName must contain only letters.")]
    public string LastName { get; init; }

    [Required(ErrorMessage = "Phone Number is a required field. It cannot be empty.")]
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string PhoneNumber { get; init; }

    [Required(ErrorMessage = "Date of Birth is a required field. It cannot be empty.")]
    [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
    public DateTime DateOfBirth { get; init; }

    [Required(ErrorMessage = "IsActive is a required field. It cannot be empty.")]
    public bool IsActive { get; init; }

    [Required(ErrorMessage = "CreatedDate is a required field. It cannot be empty.")]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime CreatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? UpdatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? DeletedDate { get; init; }
}
