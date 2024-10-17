using Entities.Concretes;

namespace Extensions
{
    public static class TreatmentTypeExtensions
    {
        public static IQueryable<TreatmentType> FilterByName(this IQueryable<TreatmentType> treatmentTypes, string? nameContains)
        {
            if (!string.IsNullOrWhiteSpace(nameContains))
            {
                treatmentTypes = treatmentTypes.Where(tt => tt.Name.Trim().ToLower().Contains(nameContains.Trim().ToLower()));
            }

            return treatmentTypes;
        }

        public static IQueryable<TreatmentType> FilterByPriceRange(this IQueryable<TreatmentType> treatmentTypes, decimal? minPrice, decimal? maxPrice)
        {
            if (minPrice.HasValue)
            {
                treatmentTypes = treatmentTypes.Where(tt => tt.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                treatmentTypes = treatmentTypes.Where(tt => tt.Price <= maxPrice.Value);
            }

            return treatmentTypes;
        }

        public static IQueryable<TreatmentType> FilterCreatedDate(this IQueryable<TreatmentType> treatmentTypes, DateTime? minDate, DateTime? maxDate)
        {
            if (minDate.HasValue)
            {
                treatmentTypes = treatmentTypes.Where(i => i.CreatedDate >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                treatmentTypes = treatmentTypes.Where(i => i.CreatedDate <= maxDate.Value);
            }

            return treatmentTypes;
        }
    }
}
