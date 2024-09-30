using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.TreatmentDtos;

public record TreatmentDtoForUpdate:TreatmentDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; }

    public Guid? AppointmentId { get; init; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be between 0.01 and the maximum value.")]
    public decimal? TotalAmount { get; init; }

    public Guid? PatientId { get; init; }

    public Guid? DentistId { get; init; }

    [JsonIgnore]
    [Required(ErrorMessage = "UpdatedDate is a required field. It cannot be empty.")]
    public DateTime UpdatedDate { get; init; }
}
