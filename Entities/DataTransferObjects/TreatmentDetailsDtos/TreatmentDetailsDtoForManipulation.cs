using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.TreatmentDetailsDtos;

public abstract record TreatmentDetailsDtoForManipulation
{
    [Required(ErrorMessage = "Id is a required field. It cannot be empty.")]
    public Guid Id { get; init; }
}
