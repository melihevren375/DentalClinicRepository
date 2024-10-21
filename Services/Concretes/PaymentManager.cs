using AutoMapper;
using Entities.Concretes;
using Entities.DataTransferObjects.PaymentDtos;
using Entities.Exceptions.NotFoundExceptions;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services.Concretes;

public class PaymentManager : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMapper _mapper;
    private readonly IDataShaper<PaymentDtoForRead> _dataShaperOfPaymentDtoForRead;

    public PaymentManager(IPaymentRepository paymentRepository, IMapper mapper, IDataShaper<PaymentDtoForRead> dataShaperOfPaymentDtoForRead)
    {
        _paymentRepository = paymentRepository;
        _mapper = mapper;
        _dataShaperOfPaymentDtoForRead = dataShaperOfPaymentDtoForRead;
    }

    public async Task CreatePaymentAsync(PaymentDtoForInsertion paymentDtoForInsertion)
    {
        Payment Payment = _mapper.Map<Payment>(paymentDtoForInsertion);
        await _paymentRepository.CreatePaymentAsync(Payment);
    }

    public async Task DeletePaymentAsync(Guid id, bool trackChanges)
    {
        Payment payment = await CheckAndReturnPaymentAsync(id, trackChanges);
        await _paymentRepository.DeletePaymentAsync(payment);
    }

    public async Task<(IEnumerable<ExpandoObject> PaymentDtosForRead, MetaData metaData)> GetPayments(PaymentParams PaymentParams)
    {
        var pagedListResults = await _paymentRepository.GetPaymentsAsync(PaymentParams);
        var metaData = pagedListResults.MetaData;
        var dtos = _mapper.Map<IEnumerable<PaymentDtoForRead>>(pagedListResults);
        var dataShaper = _dataShaperOfPaymentDtoForRead.ShapeData(dtos, PaymentParams.Fields);
        return (dataShaper, metaData);
    }

    public async Task UpdatePaymentAsync(Guid id, bool trackChanges, PaymentDtoForUpdate paymentDtoForUpdate)
    {
        Payment payment = await CheckAndReturnPaymentAsync(id, trackChanges);
        _mapper.Map(paymentDtoForUpdate, payment);
        await _paymentRepository.UpdatePaymentAsync(payment);
    }

    private async Task<Payment> CheckAndReturnPaymentAsync(Guid id, bool trackChanges)
    {
        var result = await _paymentRepository.GetPaymentByConditionAsync(a => a.Id.Equals(id), trackChanges);

        if (result is null)
            throw new PaymentNotFoundException(id);

        return result;
    }
}
