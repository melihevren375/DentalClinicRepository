using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects;

public abstract record PaymentDtoForManipulation
{
    [Required(ErrorMessage = "Id is a required field. It cannot be empty.")]
    public Guid Id { get; init; }
}
