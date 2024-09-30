using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.TreatmentTypeDtos;

public record TreatmentTypeDtoForRead:TreatmentTypeDtoForManipulation
{
    [Required(ErrorMessage = "Name is a required field. It cannot be empty.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
    public string Name { get; init; }

    [Required(ErrorMessage = "Price is a required field. It cannot be empty.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be between 0.01 and the maximum value.")]
    public decimal Price { get; init; }

    [Required(ErrorMessage = "CreatedDate is a required field. It cannot be empty.")]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime CreatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? UpdatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? DeletedDate { get; init; }
}
