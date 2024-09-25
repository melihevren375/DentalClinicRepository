using Entities.ValidationAttiributes;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects;

public record PaymentDtoForInsertion : PaymentDtoForManipulation
{
    [Required(ErrorMessage = "InvoiceId zorunlu bir alandır. Boş olamaz.")]
    public Guid InvoiceId { get; init; }

    [Required(ErrorMessage = "Amount zorunlu bir alandır. Boş olamaz.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount 0.01 ile maksimum değer arasında olmalıdır.")]
    public decimal Amount { get; init; }

    [Required(ErrorMessage = "PaymentDate zorunlu bir alandır. Boş olamaz.")]
    [PastDate]
    [DataType(DataType.DateTime, ErrorMessage = "Lütfen geçerli bir tarih girin.")]
    public DateTime PaymentDate { get; init; }

    [Required(ErrorMessage = "PaymentMethodId zorunlu bir alandır. Boş olamaz.")]
    public Guid PaymentMethodId { get; init; }

    public string? Notes { get; init; }
}
