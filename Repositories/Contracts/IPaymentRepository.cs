using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IPaymentRepository : IBaseRepository<Payment>
{
    Task<PagedList<Payment>> GetPaymentsAsync(PaymentParams paymentParams);
    Task<Payment> GetPaymentByConditionAsync(Expression<Func<Payment, bool>> expression,bool trackChanges);
    Task CreatePaymentAsync(Payment payment);
    Task DeletePaymentAsync(Payment payment);
    Task UpdatePaymentAsync(Payment payment);
}
