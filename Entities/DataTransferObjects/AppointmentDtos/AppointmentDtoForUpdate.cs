using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.AppointmentDtos;

public record AppointmentDtoForUpdate : AppointmentDtoForManipulation
{
    [JsonIgnore]
    public new Guid? Id { get; init; }

    public Guid? PatientId { get; init; }

    public Guid? DentistId { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid datetime.")]
    public DateTime? DateOfAppointment { get; init; }

    [StringLength(500, ErrorMessage = "The max value of the notes must be 500 characters.")]
    public string? Notes { get; init; }

    public bool? IsActive { get; init; }

    [JsonIgnore]
    [Required(ErrorMessage = "UpdatedDate is a required field. It cannot be empty.")]
    public DateTime UpdatedDate { get; init; }
}
