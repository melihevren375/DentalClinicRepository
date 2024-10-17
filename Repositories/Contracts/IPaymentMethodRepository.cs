using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IPaymentMethodRepository : IBaseRepository<PaymentMethod>
{
    Task<PagedList<PaymentMethod>> GetPaymentMethodsAsync(PaymentMethodParams paymentMethodParams);
    Task<PaymentMethod> GetPaymentMethodByConditionAsync(Expression<Func<PaymentMethod, bool>> expression,bool trackChanges);
    Task CreatePaymentMethodAsync(PaymentMethod paymentMethod);
    Task DeletePaymentMethodAsync(PaymentMethod paymentMethod);
    Task UpdatePaymentMethodAsync(PaymentMethod paymentMethod);
}
