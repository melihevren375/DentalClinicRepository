﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.TreatmentTypeDtos;

public record TreatmentTypeDtoForInsertion:TreatmentTypeDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; }

    [Required(ErrorMessage = "Name is a required field. It cannot be empty.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
    public string Name { get; init; }

    [Required(ErrorMessage = "Price is a required field. It cannot be empty.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be between 0.01 and the maximum value.")]
    public decimal Price { get; init; }

    [JsonIgnore]
    public DateTime CreatedDate { get; init; }
}
