using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IInvoiceRepository : IBaseRepository<Invoice>
{
    Task<PagedList<Invoice>> GetInvoicesAsync(InvoiceParams invoiceParams);
    Task<Invoice> GetInvoiceByConditionAsync(Expression<Func<Invoice, bool>> expression);
    void CreateInvoiceAsync(Invoice invoice);
    void DeleteInvoiceAsync(Invoice invoice);
    void UpdateInvoiceAsync(Invoice invoice);
}
