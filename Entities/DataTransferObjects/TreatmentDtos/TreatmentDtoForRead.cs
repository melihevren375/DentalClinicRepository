using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.TreatmentDtos;

public record TreatmentDtoForRead : TreatmentDtoForManipulation
{
    [Required(ErrorMessage = "AppointmentId is a required field. It cannot be empty.")]
    public Guid AppointmentId { get; init; }

    [Required(ErrorMessage = "TotalAmount is a required field. It cannot be empty.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be between 0.01 and the maximum value.")]
    public decimal TotalAmount { get; init; }

    [Required(ErrorMessage = "PatientId is a required field. It cannot be empty.")]
    public Guid PatientId { get; init; }

    [Required(ErrorMessage = "DentistId is a required field. It cannot be empty.")]
    public Guid DentistId { get; init; }

    [Required(ErrorMessage = "CreatedDate is a required field. It cannot be empty.")]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime CreatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? UpdatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? DeletedDate { get; init; }
}
