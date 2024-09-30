using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.TreatmentTypeDtos;

public abstract record TreatmentTypeDtoForManipulation
{
    [Required(ErrorMessage = "Id is a required field. It cannot be empty.")]
    public Guid Id { get; init; }
}
