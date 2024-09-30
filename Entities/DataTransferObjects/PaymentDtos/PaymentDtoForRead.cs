using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.PaymentDtos;

public record PaymentDtoForRead : PaymentDtoForManipulation
{
    [Required(ErrorMessage = "InvoiceId is a required field. It cannot be empty.")]
    public Guid InvoiceId { get; init; }

    [Required(ErrorMessage = "Amount is a required field. It cannot be empty.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be between 0.01 and the maximum value.")]
    public decimal Amount { get; init; }

    [Required(ErrorMessage = "PaymentDate is a required field. It cannot be empty.")]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime PaymentDate { get; init; }

    [Required(ErrorMessage = "PaymentMethodId is a required field. It cannot be empty.")]
    public Guid PaymentMethodId { get; init; }

    [StringLength(500, ErrorMessage = "The max value of the notes must be 500 characters.")]
    public string? Notes { get; init; }

    [Required(ErrorMessage = "CreatedDate is a required field. It cannot be empty.")]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime CreatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? UpdatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? DeletedDate { get; init; }
}
