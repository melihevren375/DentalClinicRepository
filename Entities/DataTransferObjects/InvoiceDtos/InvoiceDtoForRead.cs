using Entities.ValidationAttiributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.InvoiceDtos;

public record InvoiceDtoForRead:InvoiceDtoForManipulation
{

    [Required(ErrorMessage = "PatientId is a required field. It cannot be empty.")]
    public Guid PatientId { get; init; }

    [Required(ErrorMessage = "TotalAmount is a required field. It cannot be empty.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "TotalAmount must be between 0.01 and the maximum value.")]
    public decimal TotalAmount { get; init; }

    [Required(ErrorMessage = "IssueDate is a required field. It cannot be empty.")]
    [PastDate]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid datetime.")]
    public DateTime IssueDate { get; init; }

    public bool IsPaid { get; init; }

    public string? Notes { get; init; }

    [Required(ErrorMessage = "CreatedDate is a required field. It cannot be empty.")]
    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime CreatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? UpdatedDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
    public DateTime? DeletedDate { get; init; }
}
