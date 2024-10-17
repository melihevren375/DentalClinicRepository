using Entities.Concretes;

namespace Extensions
{
    public static class TreatmentExtensions
    {
        public static IQueryable<Treatment> FilterByTotalAmount(this IQueryable<Treatment> treatments, decimal? minTotalAmount, decimal? maxTotalAmount)
        {
            if (minTotalAmount.HasValue)
            {
                treatments = treatments.Where(t => t.TotalAmount >= minTotalAmount.Value);
            }

            if (maxTotalAmount.HasValue)
            {
                treatments = treatments.Where(t => t.TotalAmount <= maxTotalAmount.Value);
            }

            return treatments;
        }

        public static IQueryable<Treatment> FilterByPatientId(this IQueryable<Treatment> treatments, Guid? patientId)
        {
            if (patientId.HasValue)
            {
                treatments = treatments.Where(t => t.PatientId == patientId.Value);
            }

            return treatments;
        }

        public static IQueryable<Treatment> FilterByDentistId(this IQueryable<Treatment> treatments, Guid? dentistId)
        {
            if (dentistId.HasValue)
            {
                treatments = treatments.Where(t => t.DentistId == dentistId.Value);
            }

            return treatments;
        }

        public static IQueryable<Treatment> FilterByAppointmentId(this IQueryable<Treatment> treatments, Guid? appointmentId)
        {
            if (appointmentId.HasValue)
            {
                treatments = treatments.Where(t => t.AppointmentId == appointmentId.Value);
            }

            return treatments;
        }

        public static IQueryable<Treatment> FilterCreatedDate(this IQueryable<Treatment> treatments, DateTime? minDate, DateTime? maxDate)
        {
            if (minDate.HasValue)
            {
                treatments = treatments.Where(i => i.CreatedDate >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                treatments = treatments.Where(i => i.CreatedDate <= maxDate.Value);
            }

            return treatments;
        }
    }
}
