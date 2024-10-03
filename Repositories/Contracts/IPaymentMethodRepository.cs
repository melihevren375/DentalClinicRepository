using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IPaymentMethodRepository : IBaseRepository<PaymentMethod>
{
    Task<PagedList<PaymentMethod>> GetPaymentMethodsAsync(PaymentMethodParams paymentMethodParams);
    Task<PaymentMethod> GetPaymentMethodByConditionAsync(Expression<Func<PaymentMethod, bool>> expression);
    void CreatePaymentMethodAsync(PaymentMethod paymentMethod);
    void DeletePaymentMethodAsync(PaymentMethod paymentMethod);
    void UpdatePaymentMethodAsync(PaymentMethod paymentMethod);
}
