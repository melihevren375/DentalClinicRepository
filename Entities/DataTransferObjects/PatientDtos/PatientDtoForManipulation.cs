using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.PatientDtos;

public abstract record PatientDtoForManipulation
{
    [Required(ErrorMessage = "Id is a required field. It cannot be empty.")]
    public Guid Id { get; init; }
}
