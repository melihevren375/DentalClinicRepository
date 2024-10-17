using Entities.Concretes;

namespace Repositories.Concretes.EfCore.Repository_Extensions;

public static class DentistExtensions
{
    public static IQueryable<Dentist> FilterCreatedDate(this IQueryable<Dentist> dentists, DateTime? minDate, DateTime? maxDate)
    {
        if(minDate.HasValue)
        {
            dentists = dentists.Where(d => d.CreatedDate >= minDate.Value);
        }

        if (maxDate.HasValue) 
        {
            dentists = dentists.Where(d => d.CreatedDate <= maxDate.Value);
        }

        return dentists;
    }

    public static IQueryable<Dentist> FilterByIsActive(this IQueryable<Dentist> dentists, bool? isActive)
    {
        if (isActive is null)
            return dentists;

        return dentists.Where(d => d.IsActive == isActive);
    }

    public static IQueryable<Dentist> FilterByFirstName(this IQueryable<Dentist> dentists, string? firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            return dentists;

        firstName = firstName.Trim().ToLower();
        return dentists.Where(d => d.FirstName.ToLower().Contains(firstName));
    }

    public static IQueryable<Dentist> FilterByLastName(this IQueryable<Dentist> dentists, string? lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            return dentists;

        lastName = lastName.Trim().ToLower();
        return dentists.Where(d => d.LastName.ToLower().Contains(lastName));
    }

    public static IQueryable<Dentist> FilterByPhoneNumber(this IQueryable<Dentist> dentists, string? phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return dentists;

        phoneNumber = phoneNumber.Trim();
        return dentists.Where(d => d.PhoneNumber.Contains(phoneNumber));
    }

    public static IQueryable<Dentist> FilterBySpecialty(this IQueryable<Dentist> dentists, string? specialty)
    {
        if (string.IsNullOrWhiteSpace(specialty))
            return dentists;

        specialty = specialty.Trim().ToLower();
        return dentists.Where(d => d.Specialty.ToLower().Contains(specialty));
    }

    public static IQueryable<Dentist> FilterByBirthDateRange(this IQueryable<Dentist> dentists, DateTime? minBirthDate, DateTime? maxBirthDate)
    {
        if (minBirthDate.HasValue)
        {
            dentists = dentists.Where(d => d.DateOfBirth >= minBirthDate.Value);
        }

        if (maxBirthDate.HasValue)
        {
            dentists = dentists.Where(d => d.DateOfBirth <= maxBirthDate.Value);
        }

        return dentists;
    }

}
