using Entities.Concretes;
using Entities.RequestFeatures;
using Extensions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.Concretes.EfCore.Repos;

public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task CreatePaymentAsync(Payment payment) => await CreateEntityAsync(payment);

    public async Task DeletePaymentAsync(Payment payment) => await DeleteEntityAsync(payment);

    public async Task<Payment> GetPaymentByConditionAsync(Expression<Func<Payment, bool>> expression, bool trackChanges)
    {
        var result = await GetEntitiesByCondition(expression, trackChanges).
            SingleOrDefaultAsync();

        return result;
    }

    public async Task<PagedList<Payment>> GetPaymentsAsync(PaymentParams paymentParams)
    {
        var results = await GetEntities(paymentParams).
            FilterByAmount(paymentParams.MinAmount, paymentParams.MaxAmount).
            FilterByInvoiceId(paymentParams.InvoiceId).
            FilterByNotes(paymentParams.NotesContains).
            FilterByPaymentDate(paymentParams.MinPaymentDate, paymentParams.MaxCreatedDate).
            FilterByPaymentMethodId(paymentParams.PaymentMethodId).
            FilterCreatedDate(paymentParams.MinCreatedDate, paymentParams.MaxCreatedDate).
            ToListAsync();

        return PagedList<Payment>.ToPagedList(results, paymentParams.PageNumber, paymentParams.PageSize);
    }

    public async Task UpdatePaymentAsync(Payment payment) => await UpdateEntityAsync(payment);

}
