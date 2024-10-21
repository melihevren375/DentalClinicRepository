using Entities.DataTransferObjects.InvoiceDtos;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts;

public interface IInvoiceService
{
    Task CreateInvoiceAsync(InvoiceDtoForInsertion invoiceDtoForInsertion);
    Task DeleteInvoiceAsync(Guid id, bool trackChanges);
    Task UpdateInvoiceAsync(Guid id, bool trackChanges, InvoiceDtoForUpdate invoiceDtoForUpdate);
    Task<(IEnumerable<ExpandoObject> InvoiceDtosForRead, MetaData metaData)> GetInvoices(InvoiceParams invoiceParams);
}
