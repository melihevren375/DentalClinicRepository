using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.ReceptionistDtos;

public abstract record ReceptionistDtoForManipulation
{
    [Required(ErrorMessage = "Id is a required field. It cannot be empty.")]
    public Guid Id { get; init; }
}
