using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.AppointmentDtos;

public abstract record AppointmentDtoForManipulation
{
    [Required(ErrorMessage ="Id is a required field. It cannot be empty.")]
    public Guid Id { get; init; }
}
