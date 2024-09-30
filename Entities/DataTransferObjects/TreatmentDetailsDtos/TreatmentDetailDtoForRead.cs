using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.TreatmentDetailsDtos;

public record TreatmentDetailDtoForRead : TreatmentDetailsDtoForManipulation
{
    public Guid TreatmentId { get; init; }

    public Guid TreatmentTypeId { get; init; }

    [RegularExpression(@"^\d+$", ErrorMessage = "ToothNumber must be a valid integer number.")]
    public int? ToothNumber { get; init; }

    [StringLength(500, ErrorMessage = "The max value of the notes must be 500 characters.")]
    public string? Notes { get; init; }

    public bool IsCompleted { get; init; }

    [Required(ErrorMessage = "CreatedDate is a required field. It cannot be empty.")]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime CreatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? UpdatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? DeletedDate { get; init; }
}
