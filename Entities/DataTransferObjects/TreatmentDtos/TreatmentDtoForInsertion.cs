using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.TreatmentDtos;

public record TreatmentDtoForInsertion : TreatmentDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; }

    [Required(ErrorMessage = "AppointmentId is a required field. It cannot be empty.")]
    public Guid AppointmentId { get; init; }

    [Required(ErrorMessage = "TotalAmount is a required field. It cannot be empty.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be between 0.01 and the maximum value.")]
    public decimal TotalAmount { get; init; }

    [Required(ErrorMessage = "PatientId is a required field. It cannot be empty.")]
    public Guid PatientId { get; init; }

    [Required(ErrorMessage = "DentistId is a required field. It cannot be empty.")]
    public Guid DentistId { get; init; }

    [JsonIgnore]
    public DateTime CreatedDate { get; init; }
}
