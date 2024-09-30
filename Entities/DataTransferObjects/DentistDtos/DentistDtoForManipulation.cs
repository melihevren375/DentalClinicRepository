using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.DentistDtos;

public abstract record DentistDtoForManipulation
{
    [Required(ErrorMessage = "Id is a required field. It cannot be empty.")]
    public Guid Id { get; init; }
}
