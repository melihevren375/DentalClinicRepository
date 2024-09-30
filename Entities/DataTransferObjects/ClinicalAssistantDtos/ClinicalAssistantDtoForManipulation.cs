using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.ClinicalAssistantDtos;

public abstract record ClinicalAssistantDtoForManipulation
{
    [Required(ErrorMessage = "Id is a required field. It cannot be empty.")]
    public Guid Id { get; init; }
}
