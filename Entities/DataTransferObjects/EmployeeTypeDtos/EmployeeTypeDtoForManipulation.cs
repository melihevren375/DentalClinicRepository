using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.EmployeeTypeDtos;

public abstract record EmployeeTypeDtoForManipulation
{
    [Required(ErrorMessage = "Id is a required field. It cannot be empty.")]
    public Guid Id { get; init; }
}
