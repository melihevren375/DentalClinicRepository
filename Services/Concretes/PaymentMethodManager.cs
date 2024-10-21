using AutoMapper;
using Entities.Concretes;
using Entities.DataTransferObjects.PaymentMethodDtos;
using Entities.Exceptions.NotFoundExceptions;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services.Concretes;

public class PaymentMethodManager : IPaymentMethodService
{
    private readonly IPaymentMethodRepository _paymentMethodRepository;
    private readonly IMapper _mapper;
    private readonly IDataShaper<PaymentMethodDtoForRead> _dataShaperOfPaymentMethodDtoForRead;

    public PaymentMethodManager(IPaymentMethodRepository paymentMethodRepository, IMapper mapper, IDataShaper<PaymentMethodDtoForRead> dataShaperOfPaymentMethodDtoForRead)
    {
        _paymentMethodRepository = paymentMethodRepository;
        _mapper = mapper;
        _dataShaperOfPaymentMethodDtoForRead = dataShaperOfPaymentMethodDtoForRead;
    }

    public async Task CreatePaymentMethodAsync(PaymentMethodDtoForInsertion paymentMethodDtoForInsertion)
    {
        PaymentMethod paymentMethod = _mapper.Map<PaymentMethod>(paymentMethodDtoForInsertion);
        await _paymentMethodRepository.CreatePaymentMethodAsync(paymentMethod);
    }

    public async Task DeletePaymentMethodAsync(Guid id, bool trackChanges)
    {
        PaymentMethod paymentMethod = await CheckAndReturnPaymentAsync(id, trackChanges);
        await _paymentMethodRepository.DeletePaymentMethodAsync(paymentMethod);
    }

    public async Task<(IEnumerable<ExpandoObject> PaymentMethodDtosForRead, MetaData metaData)> GetPaymentMethods(PaymentMethodParams paymentMethodParams)
    {
        var pagedListResults = await _paymentMethodRepository.
            GetPaymentMethodsAsync(paymentMethodParams);
        var metaData = pagedListResults.MetaData;
        var dtos = _mapper.Map<IEnumerable<PaymentMethodDtoForRead>>(pagedListResults);
        var dataShaper = _dataShaperOfPaymentMethodDtoForRead.ShapeData(dtos,paymentMethodParams);
        return (dataShaper, metaData);
    }

    public async Task UpdatePaymentMethodAsync(Guid id, bool trackChanges, PaymentMethodDtoForUpdate paymentMethodDtoForUpdate)
    {
        PaymentMethod paymentMethod = await CheckAndReturnPaymentAsync(id, trackChanges);
        _mapper.Map(paymentMethodDtoForUpdate, paymentMethod);
        await _paymentMethodRepository.UpdatePaymentMethodAsync(paymentMethod);
    }

    private async Task<PaymentMethod> CheckAndReturnPaymentAsync(Guid id, bool trackChanges)
    {
        PaymentMethod paymentMethod = await _paymentMethodRepository.GetPaymentMethodByConditionAsync(id, trackChanges);

        if (paymentMethod is null)
            throw new PaymentMethodNotFoundExpcetion(id);

        return paymentMethod;
    }
}
