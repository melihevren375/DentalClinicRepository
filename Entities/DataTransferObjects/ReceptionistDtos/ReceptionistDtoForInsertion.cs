using Entities.ValidationAttiributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.ReceptionistDtos;

public record ReceptionistDtoForInsertion:ReceptionistDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; }

    [Required(ErrorMessage = "First Name is a required field. It cannot be empty.")]
    [StringLength(100, ErrorMessage = "First Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
    public string FirstName { get; init; }

    [Required(ErrorMessage = "Last Name is a required field. It cannot be empty.")]
    [StringLength(100, ErrorMessage = "Last Name cannot exceed 100 characters.")]
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

    [JsonIgnore]
    public DateTime CreatedDate { get; init; }
}
