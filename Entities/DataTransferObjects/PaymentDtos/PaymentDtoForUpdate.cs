using Entities.ValidationAttiributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.PaymentDtos;

public record PaymentDtoForUpdate : PaymentDtoForManipulation
{
    [JsonIgnore]
    public new Guid? Id { get; init; }

    public Guid? InvoiceId { get; init; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be between 0.01 and the maximum value.")]
    public decimal? Amount { get; init; }

    [PastDate]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? PaymentDate { get; init; }

    public Guid? PaymentMethodId { get; init; }

    [StringLength(500, ErrorMessage = "The max value of the notes must be 500 characters.")]
    public string? Notes { get; init; }

    [JsonIgnore]
    [Required(ErrorMessage = "UpdatedDate is a required field. It cannot be empty.")]
    public DateTime UpdatedDate { get; init; }
}
