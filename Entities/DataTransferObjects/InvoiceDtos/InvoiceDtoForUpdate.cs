using Entities.ValidationAttiributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.InvoiceDtos;

public record InvoiceDtoForUpdate:InvoiceDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; }

    public Guid? PatientId { get; init; }

    [Range(0.01, double.MaxValue, ErrorMessage = "TotalAmount must be between 0.01 and the maximum value.")]
    public decimal? TotalAmount { get; init; }

    [PastDate]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid datetime.")]
    public DateTime? IssueDate { get; init; }

    public bool? IsPaid { get; init; }

    public string? Notes { get; init; }

    [JsonIgnore]
    [Required(ErrorMessage = "UpdatedDate is a required field. It cannot be empty.")]
    public DateTime UpdatedDate { get; init; }
}
