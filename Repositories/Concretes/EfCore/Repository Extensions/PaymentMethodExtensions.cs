using Entities.Concretes;

namespace Repositories.Concretes.EfCore.Repository_Extensions;

public static class PaymentMethodExtensions
{
    public static IQueryable<PaymentMethod> FilterByName(this IQueryable<PaymentMethod> paymentMethods, string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return paymentMethods;

        name = name.Trim().ToLower();
        return paymentMethods.Where(pm => pm.Name.ToLower().Contains(name));
    }

    public static IQueryable<PaymentMethod> FilterCreatedDate(this IQueryable<PaymentMethod> paymentMethods, DateTime? minDate, DateTime? maxDate)
    {
        if (minDate.HasValue)
        {
            paymentMethods = paymentMethods.Where(i => i.CreatedDate >= minDate.Value);
        }

        if (maxDate.HasValue)
        {
            paymentMethods = paymentMethods.Where(i => i.CreatedDate <= maxDate.Value);
        }

        return paymentMethods;
    }
}
