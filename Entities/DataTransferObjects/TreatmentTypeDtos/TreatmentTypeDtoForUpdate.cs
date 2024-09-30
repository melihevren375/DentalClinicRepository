using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.TreatmentTypeDtos;

public record TreatmentTypeDtoForUpdate : TreatmentTypeDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; }

    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
    public string? Name { get; init; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be between 0.01 and the maximum value.")]
    public decimal? Price { get; init; }

    [JsonIgnore]
    [Required(ErrorMessage = "UpdatedDate is a required field. It cannot be empty.")]
    public DateTime UpdatedDate { get; init; }
}
