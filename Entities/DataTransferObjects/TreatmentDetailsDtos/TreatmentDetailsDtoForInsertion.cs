using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.TreatmentDetailsDtos;

public record TreatmentDetailsDtoForInsertion:TreatmentDetailsDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; }

    [Required(ErrorMessage = "TreatmentId is a required field. It cannot be empty.")]
    public Guid TreatmentId { get; init; }

    [Required(ErrorMessage = "TreatmentTypeId is a required field. It cannot be empty.")]
    public Guid TreatmentTypeId { get; init; }

    [RegularExpression(@"^\d+$", ErrorMessage = "ToothNumber must be a valid integer number.")]
    public int? ToothNumber { get; init; }

    [StringLength(500, ErrorMessage = "The max value of the notes must be 500 characters.")]
    public string? Notes { get; init; }

    public bool IsCompleted { get; init; }

    [JsonIgnore]
    public DateTime CreatedDate { get; init; }
}
