using Entities.DataTransferObjects.PaymentMethodDtos;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts;

public interface IPaymentMethodService
{
    Task CreatePaymentMethodAsync(PaymentMethodDtoForInsertion paymentMethodDtoForInsertion);
    Task DeletePaymentMethodAsync(Guid id, bool trackChanges);
    Task UpdatePaymentMethodAsync(Guid id, bool trackChanges, PaymentMethodDtoForUpdate paymentMethodDtoForUpdate);
    Task<(IEnumerable<ExpandoObject> PaymentMethodDtosForRead, MetaData metaData)> GetPaymentMethods(PaymentMethodParams paymentMethodParams);
}
