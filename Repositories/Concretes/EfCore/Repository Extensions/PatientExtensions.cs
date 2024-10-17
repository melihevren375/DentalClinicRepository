using Entities.Concretes;

namespace Extensions
{
    public static class PatientExtensions
    {
        public static IQueryable<Patient> FilterByFirstName(this IQueryable<Patient> patients, string? firstNameContains)
        {
            if (string.IsNullOrWhiteSpace(firstNameContains))
                return patients;

            firstNameContains = firstNameContains.Trim().ToLower();
            return patients.Where(p => p.FirstName.ToLower().Contains(firstNameContains));
        }

        public static IQueryable<Patient> FilterByLastName(this IQueryable<Patient> patients, string? lastNameContains)
        {
            if (string.IsNullOrWhiteSpace(lastNameContains))
                return patients;

            lastNameContains = lastNameContains.Trim().ToLower();
            return patients.Where(p => p.LastName.ToLower().Contains(lastNameContains));
        }

        public static IQueryable<Patient> FilterByPhoneNumber(this IQueryable<Patient> patients, string? phoneNumberContains)
        {
            if (string.IsNullOrWhiteSpace(phoneNumberContains))
                return patients;

            phoneNumberContains = phoneNumberContains.Trim();
            return patients.Where(p => p.PhoneNumber.Contains(phoneNumberContains));
        }

        public static IQueryable<Patient> FilterByDateOfBirthRange(this IQueryable<Patient> patients, DateTime? minDateOfBirth, DateTime? maxDateOfBirth)
        {
            if (minDateOfBirth.HasValue)
            {
                patients = patients.Where(p => p.DateOfBirth >= minDateOfBirth.Value);
            }

            if (maxDateOfBirth.HasValue)
            {
                patients = patients.Where(p => p.DateOfBirth <= maxDateOfBirth.Value);
            }

            return patients;
        }

        public static IQueryable<Patient> FilterByIsActive(this IQueryable<Patient> patients, bool? isActive)
        {
            if (isActive.HasValue)
            {
                patients = patients.Where(p => p.IsActive == isActive.Value);
            }

            return patients;
        }

        public static IQueryable<Patient> FilterCreatedDate(this IQueryable<Patient> patients, DateTime? minDate, DateTime? maxDate)
        {
            if (minDate.HasValue)
            {
                patients = patients.Where(i => i.CreatedDate >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                patients = patients.Where(i => i.CreatedDate <= maxDate.Value);
            }

            return patients;
        }
    }
}
