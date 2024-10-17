using Entities.Concretes;

namespace Repositories.Concretes.EfCore.Repository_Extensions;

public static class ClinicalAssistantExtensions
{
    public static IQueryable<ClinicalAssistant> FilterCreatedDate(this IQueryable<ClinicalAssistant> clinicalAssistants, DateTime? minDate, DateTime? maxDate)
    {
        if (minDate.HasValue)
        {
            clinicalAssistants = clinicalAssistants.Where(a => a.CreatedDate >= minDate.Value);
        }

        if (maxDate.HasValue)
        {
            clinicalAssistants = clinicalAssistants.Where(a => a.CreatedDate <= maxDate.Value);
        }

        return clinicalAssistants;
    }

    public static IQueryable<ClinicalAssistant> FilterByIsActive(this IQueryable<ClinicalAssistant> assistants, bool? isActive)
    {
        if (isActive is null)
            return assistants;

        return assistants.Where(ca => ca.IsActive == isActive);
    }

    public static IQueryable<ClinicalAssistant> FilterByFirstName(this IQueryable<ClinicalAssistant> assistants, string? firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            return assistants;

        firstName = firstName.Trim().ToLower();
        return assistants.Where(ca => ca.FirstName.ToLower().Contains(firstName));
    }

    public static IQueryable<ClinicalAssistant> FilterByLastName(this IQueryable<ClinicalAssistant> assistants, string? lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            return assistants;

        lastName = lastName.Trim().ToLower();
        return assistants.Where(ca => ca.LastName.ToLower().Contains(lastName));
    }

    public static IQueryable<ClinicalAssistant> FilterByPhoneNumber(this IQueryable<ClinicalAssistant> assistants, string? phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return assistants;

        phoneNumber = phoneNumber.Trim();
        return assistants.Where(ca => ca.PhoneNumber.Contains(phoneNumber));
    }

    public static IQueryable<ClinicalAssistant> FilterBySpecialty(this IQueryable<ClinicalAssistant> assistants, string? specialty)
    {
        if (string.IsNullOrWhiteSpace(specialty))
            return assistants;

        specialty = specialty.Trim().ToLower();
        return assistants.Where(ca => ca.SpecialtyArea.ToLower().Contains(specialty));
    }

    public static IQueryable<ClinicalAssistant> FilterByBirthDateRange(this IQueryable<ClinicalAssistant> assistants, DateTime? minBirthDate, DateTime? maxBirthDate)
    {
        if (minBirthDate.HasValue)
        {
            assistants = assistants.Where(ca => ca.DateOfBirth >= minBirthDate.Value);
        }

        if (maxBirthDate.HasValue)
        {
            assistants = assistants.Where(a => a.DateOfBirth <= maxBirthDate.Value);
        }

        return assistants;
    }

}
