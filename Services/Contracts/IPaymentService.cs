using Entities.DataTransferObjects.PaymentDtos;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts;

public interface IPaymentService
{
    Task CreatePaymentAsync(PaymentDtoForInsertion paymentDtoForInsertion);
    Task DeletePaymentAsync(Guid id, bool trackChanges);
    Task UpdatePaymentAsync(Guid id, bool trackChanges, PaymentDtoForUpdate paymentDtoForUpdate);
    Task<(IEnumerable<ExpandoObject> PaymentDtosForRead, MetaData metaData)> GetPayments(PaymentParams paymentParams);
}
