﻿using Entities.DataTransferObjects.PaymentDtos;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.DataTransferObjects.PaymentMethodDtos;

public record PaymentMethodDtoForInsertion:PaymentDtoForManipulation
{
    [JsonIgnore]
    public new Guid Id { get; init; }

    [Required(ErrorMessage = "Name is a required field. It cannot be empty.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
    public string Name { get; init; }
}
