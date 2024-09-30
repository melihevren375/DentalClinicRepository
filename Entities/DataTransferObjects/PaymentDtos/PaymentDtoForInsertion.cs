using Entities.ValidationAttiributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.PaymentDtos;

public record PaymentDtoForInsertion : PaymentDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; }

    [Required(ErrorMessage = "InvoiceId is a required field. It cannot be empty.")]
    public Guid InvoiceId { get; init; }

    [Required(ErrorMessage = "Amount is a required field. It cannot be empty.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be between 0.01 and the maximum value.")]
    public decimal Amount { get; init; }

    [Required(ErrorMessage = "PaymentDate is a required field. It cannot be empty.")]
    [PastDate]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime PaymentDate { get; init; }

    [Required(ErrorMessage = "PaymentMethodId is a required field. It cannot be empty.")]
    public Guid PaymentMethodId { get; init; }

    [StringLength(500, ErrorMessage = "The max value of the notes must be 500 characters.")]
    public string? Notes { get; init; }

    [JsonIgnore]
    public DateTime CreatedDate { get; init; }
}
