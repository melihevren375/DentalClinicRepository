using Entities.Concretes;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Concretes.EfCore.Repository_Extensions;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.Concretes.EfCore.Repos;

public class PaymentMethodRepository : BaseRepository<PaymentMethod>, IPaymentMethodRepository
{
    public PaymentMethodRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task CreatePaymentMethodAsync(PaymentMethod paymentMethod)
        => await CreateEntityAsync(paymentMethod);

    public async Task DeletePaymentMethodAsync(PaymentMethod paymentMethod)
        => await DeleteEntityAsync(paymentMethod);

    public async Task<PaymentMethod> GetPaymentMethodByConditionAsync(Expression<Func<PaymentMethod, bool>> expression, bool trackChanges)
    {
        var result = await GetEntitiesByCondition(expression, trackChanges).
            SingleOrDefaultAsync();

        return result;
    }

    public async Task<PagedList<PaymentMethod>> GetPaymentMethodsAsync(PaymentMethodParams paymentMethodParams)
    {
        var results = await GetEntities(paymentMethodParams).
            FilterByName(paymentMethodParams.Name).
            FilterCreatedDate(paymentMethodParams.MinCreatedDate, paymentMethodParams.MaxCreatedDate).
            ToListAsync();

        return PagedList<PaymentMethod>.ToPagedList(results, paymentMethodParams.PageNumber, paymentMethodParams.PageSize);

    }

    public async Task UpdatePaymentMethodAsync(PaymentMethod paymentMethod)
        => await UpdateEntityAsync(paymentMethod);
}
