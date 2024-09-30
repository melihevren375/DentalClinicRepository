using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.InvoiceDtos;

public abstract record InvoiceDtoForManipulation
{
    [Required]
    public Guid Id { get; init; }
}
