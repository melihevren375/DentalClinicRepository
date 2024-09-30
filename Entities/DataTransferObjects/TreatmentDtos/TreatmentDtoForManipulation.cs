using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.TreatmentDtos;

public abstract record TreatmentDtoForManipulation
{
    [Required(ErrorMessage = "Id is a required field. It cannot be empty.")]
    public Guid Id { get; init; }
}
