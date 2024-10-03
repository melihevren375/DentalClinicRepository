using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IPaymentRepository : IBaseRepository<Payment>
{
    Task<PagedList<Payment>> GetPaymentsAsync(PaymentParams paymentParams);
    Task<Payment> GetPaymentByConditionAsync(Expression<Func<Payment, bool>> expression);
    void CreatePaymentAsync(Payment payment);
    void DeletePaymentAsync(Payment payment);
    void UpdatePaymentAsync(Payment payment);
}
