using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.EmployeeTypeDtos;

public record EmployeeTypeDtoForRead : EmployeeTypeDtoForManipulation
{
    [Required(ErrorMessage = "Name is a required field. It cannot be empty.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; init; }

    [Required(ErrorMessage = "CreatedDate is a required field. It cannot be empty.")]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime CreatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? UpdatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? DeletedDate { get; init; }
}
