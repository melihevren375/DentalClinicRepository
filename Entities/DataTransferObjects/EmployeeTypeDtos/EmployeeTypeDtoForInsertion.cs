using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.EmployeeTypeDtos;

public record EmployeeTypeDtoForInsertion : EmployeeTypeDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; }

    [Required(ErrorMessage = "Name is a required field. It cannot be empty.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
    public string Name { get; init; }
}
