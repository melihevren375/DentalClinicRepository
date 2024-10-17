using Entities.Concretes;
using Entities.RequestFeatures;
using Extensions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.Concretes.EfCore.Repos;

public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task CreateInvoiceAsync(Invoice invoice) => await CreateEntityAsync(invoice);

    public async Task DeleteInvoiceAsync(Invoice invoice) => await DeleteEntityAsync(invoice);

    public async Task<Invoice> GetInvoiceByConditionAsync(Expression<Func<Invoice, bool>> expression, bool trackChanges)
    {
        var result = await GetEntitiesByCondition(expression, trackChanges).
            SingleOrDefaultAsync();

        return result;
    }

    public async Task<PagedList<Invoice>> GetInvoicesAsync(InvoiceParams invoiceParams)
    {
        var results = await GetEntities(invoiceParams).
            FilterByCreatedDate(invoiceParams.MinCreatedDate, invoiceParams.MaxCreatedDate).
            FilterByIsPaid(invoiceParams.IsPaid).
            FilterByIssueDateRange(invoiceParams.MinIssueDate, invoiceParams.MaxIssueDate).
            FilterByNotesContains(invoiceParams.NotesContains).
            FilterByTotalAmountRange(invoiceParams.MinTotalAmount, invoiceParams.MaxTotalAmount).
            ToListAsync();

        return PagedList<Invoice>.ToPagedList(results, invoiceParams.PageNumber, invoiceParams.PageSize);
    }

    public async Task UpdateInvoiceAsync(Invoice invoice) => await UpdateEntityAsync(invoice);
}
