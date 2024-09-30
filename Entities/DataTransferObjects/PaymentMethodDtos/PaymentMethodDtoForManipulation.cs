using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.PaymentMethodDtos;

public abstract record PaymentMethodDtoForManipulation
{
    [Required(ErrorMessage = "Id is a required field. It cannot be empty.")]
    public Guid Id { get; init; }
}
