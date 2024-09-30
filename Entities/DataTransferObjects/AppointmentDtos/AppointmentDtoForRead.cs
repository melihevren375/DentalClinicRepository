using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.AppointmentDtos;

public record AppointmentDtoForRead : AppointmentDtoForManipulation
{
    [Required(ErrorMessage = "PatientId is a required field. It cannot be empty.")]
    public Guid PatientId { get; init; }

    [Required(ErrorMessage = "DentistId is a required field. It cannot be empty.")]
    public Guid DentistId { get; init; }

    [Required(ErrorMessage = "DateOfAppointment is a required field. It cannot be empty.")]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid datetime.")]
    public DateTime DateOfAppointment { get; init; }

    [StringLength(500, ErrorMessage = "The max value of the notes must be 500 characters.")]
    public string? Notes { get; init; }

    [Required(ErrorMessage = "IsActive is a required field. It cannot be empty.")]
    public bool IsActive { get; init; }

    [Required(ErrorMessage = "CreatedDate is a required field. It cannot be empty.")]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime CreatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? UpdatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? DeletedDate { get; init; }
}
