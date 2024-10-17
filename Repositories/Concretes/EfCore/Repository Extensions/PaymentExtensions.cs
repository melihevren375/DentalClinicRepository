using Entities.Concretes;

namespace Extensions
{
    public static class PaymentExtensions
    {
        public static IQueryable<Payment> FilterByPaymentDate(this IQueryable<Payment> payments, DateTime? minPaymentDate, DateTime? maxPaymentDate)
        {
            if (minPaymentDate.HasValue)
            {
                payments = payments.Where(p => p.PaymentDate >= minPaymentDate.Value);
            }

            if (maxPaymentDate.HasValue)
            {
                payments = payments.Where(p => p.PaymentDate <= maxPaymentDate.Value);
            }

            return payments;
        }

        public static IQueryable<Payment> FilterByAmount(this IQueryable<Payment> payments, decimal? minAmount, decimal? maxAmount)
        {
            if (minAmount.HasValue)
            {
                payments = payments.Where(p => p.Amount >= minAmount.Value);
            }

            if (maxAmount.HasValue)
            {
                payments = payments.Where(p => p.Amount <= maxAmount.Value);
            }

            return payments;
        }

        public static IQueryable<Payment> FilterByPaymentMethodId(this IQueryable<Payment> payments, Guid? paymentMethodId)
        {
            if (paymentMethodId.HasValue)
            {
                payments = payments.Where(p => p.PaymentMethodId == paymentMethodId.Value);
            }

            return payments;
        }

        public static IQueryable<Payment> FilterByInvoiceId(this IQueryable<Payment> payments, Guid? invoiceId)
        {
            if (invoiceId.HasValue)
            {
                payments = payments.Where(p => p.InvoiceId == invoiceId.Value);
            }

            return payments;
        }

        public static IQueryable<Payment> FilterByNotes(this IQueryable<Payment> payments, string? notesContains)
        {
            if (string.IsNullOrWhiteSpace(notesContains))
                return payments;

            notesContains = notesContains.Trim().ToLower();
            return payments.Where(p => p.Notes.ToLower().Contains(notesContains));
        }

        public static IQueryable<Payment> FilterCreatedDate(this IQueryable<Payment> payments, DateTime? minDate, DateTime? maxDate)
        {
            if (minDate.HasValue)
            {
                payments = payments.Where(i => i.CreatedDate >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                payments = payments.Where(i => i.CreatedDate <= maxDate.Value);
            }

            return payments;
        }

    }
}
