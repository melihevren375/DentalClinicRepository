using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.TreatmentDetailsDtos;

public record TreatmentDetailsDtoForUpdate:TreatmentDetailsDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; }

    public Guid? TreatmentId { get; init; }

    public Guid? TreatmentTypeId { get; init; }

    [RegularExpression(@"^\d+$", ErrorMessage = "ToothNumber must be a valid integer number.")]
    public int? ToothNumber { get; init; }

    [StringLength(500, ErrorMessage = "The max value of the notes must be 500 characters.")]
    public string? Notes { get; init; }

    public bool IsCompleted { get; init; }

    [JsonIgnore]
    [Required(ErrorMessage = "UpdatedDate is a required field. It cannot be empty.")]
    public DateTime UpdatedDate { get; init; }
}
