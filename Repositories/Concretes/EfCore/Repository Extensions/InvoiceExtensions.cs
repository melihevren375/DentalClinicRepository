using Entities.Concretes;

namespace Extensions
{
    public static class InvoiceExtensions
    {
        public static IQueryable<Invoice> FilterByIssueDateRange(this IQueryable<Invoice> invoices, DateTime? minIssueDate, DateTime? maxIssueDate)
        {
            if (minIssueDate.HasValue)
            {
                invoices = invoices.Where(i => i.IssueDate >= minIssueDate.Value);
            }

            if (maxIssueDate.HasValue)
            {
                invoices = invoices.Where(i => i.IssueDate <= maxIssueDate.Value);
            }

            return invoices;
        }

        public static IQueryable<Invoice> FilterByTotalAmountRange(this IQueryable<Invoice> invoices, decimal? minTotalAmount, decimal? maxTotalAmount)
        {
            if (minTotalAmount.HasValue)
            {
                invoices = invoices.Where(i => i.TotalAmount >= minTotalAmount.Value);
            }

            if (maxTotalAmount.HasValue)
            {
                invoices = invoices.Where(i => i.TotalAmount <= maxTotalAmount.Value);
            }

            return invoices;
        }

        public static IQueryable<Invoice> FilterByIsPaid(this IQueryable<Invoice> invoices, bool? isPaid)
        {
            if (isPaid.HasValue)
            {
                invoices = invoices.Where(i => i.IsPaid == isPaid.Value);
            }

            return invoices;
        }

        public static IQueryable<Invoice> FilterByNotesContains(this IQueryable<Invoice> invoices, string? notesContains)
        {
            if (string.IsNullOrWhiteSpace(notesContains))
                return invoices;

            notesContains = notesContains.Trim().ToLower();
            return invoices.Where(i => i.Notes.ToLower().Contains(notesContains));
        }

        public static IQueryable<Invoice> FilterByCreatedDate(this IQueryable<Invoice> invoices, DateTime? minDate, DateTime? maxDate)
        {
            if (minDate.HasValue)
            {
                invoices = invoices.Where(i => i.CreatedDate >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                invoices = invoices.Where(i => i.CreatedDate <= maxDate.Value);
            }

            return invoices;
        }
    }
}
