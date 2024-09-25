using System.ComponentModel.DataAnnotations;

namespace Entities.ValidationAttiributes;

public class PastDate : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime dateTime && dateTime > DateTime.UtcNow)
        {
            return new ValidationResult(ErrorMessage ?? "Date cannot be in the future.");
        }

        return ValidationResult.Success;
    }
}
