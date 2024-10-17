using Entities.Concretes;

namespace Extensions
{
    public static class TreatmentDetailsExtensions
    {
        public static IQueryable<TreatmentDetails> FilterByToothNumber(this IQueryable<TreatmentDetails> treatmentDetails, int? minToothNumber, int? maxToothNumber)
        {
            if (minToothNumber.HasValue)
            {
                treatmentDetails = treatmentDetails.Where(td => td.ToothNumber >= minToothNumber.Value);
            }

            if (maxToothNumber.HasValue)
            {
                treatmentDetails = treatmentDetails.Where(td => td.ToothNumber <= maxToothNumber.Value);
            }

            return treatmentDetails;
        }

        public static IQueryable<TreatmentDetails> FilterByTreatmentTypeId(this IQueryable<TreatmentDetails> treatmentDetails, Guid? treatmentTypeId)
        {
            if (treatmentTypeId.HasValue)
            {
                treatmentDetails = treatmentDetails.Where(td => td.TreatmentTypeId == treatmentTypeId.Value);
            }

            return treatmentDetails;
        }

        public static IQueryable<TreatmentDetails> FilterByCompletionStatus(this IQueryable<TreatmentDetails> treatmentDetails, bool? isCompleted)
        {
            if (isCompleted.HasValue)
            {
                treatmentDetails = treatmentDetails.Where(td => td.IsCompleted == isCompleted.Value);
            }

            return treatmentDetails;
        }

        public static IQueryable<TreatmentDetails> FilterByTreatmentId(this IQueryable<TreatmentDetails> treatmentDetails, Guid? treatmentId)
        {
            if (treatmentId.HasValue)
            {
                treatmentDetails = treatmentDetails.Where(td => td.TreatmentId == treatmentId.Value);
            }

            return treatmentDetails;
        }
        public static IQueryable<TreatmentDetails> FilterByNotes(this IQueryable<TreatmentDetails> treatmentDetails, string? notesContains)
        {
            if (string.IsNullOrWhiteSpace(notesContains))
                return treatmentDetails;

            notesContains = notesContains.Trim().ToLower();
            return treatmentDetails.Where(td => td.Notes.ToLower().Contains(notesContains));
        }

        public static IQueryable<TreatmentDetails> FilterCreatedDate(this IQueryable<TreatmentDetails> treatmentDetails, DateTime? minDate, DateTime? maxDate)
        {
            if (minDate.HasValue)
            {
                treatmentDetails = treatmentDetails.Where(i => i.CreatedDate >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                treatmentDetails = treatmentDetails.Where(i => i.CreatedDate <= maxDate.Value);
            }

            return treatmentDetails;
        }
    }
}
