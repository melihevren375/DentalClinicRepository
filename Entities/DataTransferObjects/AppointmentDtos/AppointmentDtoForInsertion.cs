using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.AppointmentDtos;

public record AppointmentDtoForInsertion : AppointmentDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; }

    [Required(ErrorMessage = "PatientId is a required field. It cannot be empty.")]
    public Guid PatientId { get; init; }

    [Required(ErrorMessage = "DentistId is a required field. It cannot be empty.")]
    public Guid DentistId { get; init; }

    [Required(ErrorMessage = "DateOfAppointment is a required field. It cannot be empty.")]
    [DataType(DataType.DateTime,ErrorMessage ="Please enter a valid datetime.")]
    public DateTime DateOfAppointment { get; init; }

    [StringLength(500, ErrorMessage = "The max value of the notes must be 500 characters.")]
    public string? Notes { get; init; }

    [Required(ErrorMessage = "IsActive is a required field. It cannot be empty.")]
    public bool IsActive { get; init; }

    [JsonIgnore]
    public DateTime CreatedDate { get; init; }
}
