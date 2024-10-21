using AutoMapper;
using Entities.Concretes;
using Entities.DataTransferObjects.InvoiceDtos;
using Entities.Exceptions.NotFoundExceptions;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services.Concretes;

public class InvoiceManager : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IMapper _mapper;
    private readonly IDataShaper<InvoiceDtoForRead> dataShaperOfInvoiceDtoForRead;

    public InvoiceManager(IInvoiceRepository invoiceRepository, IMapper mapper, IDataShaper<InvoiceDtoForRead> dataShaperOfInvoiceDtoForRead)
    {
        _invoiceRepository = invoiceRepository;
        _mapper = mapper;
        this.dataShaperOfInvoiceDtoForRead = dataShaperOfInvoiceDtoForRead;
    }

    public async Task CreateInvoiceAsync(InvoiceDtoForInsertion invoiceDtoForInsertion)
    {
        Invoice invoice = _mapper.Map<Invoice>(invoiceDtoForInsertion);
        await _invoiceRepository.CreateInvoiceAsync(invoice);
    }

    public async Task DeleteInvoiceAsync(Guid id, bool trackChanges)
    {
        Invoice invoice = await CheckAndReturnInvoiceAsync(id, trackChanges);

        await _invoiceRepository.DeleteInvoiceAsync(invoice);
    }

    public async Task<(IEnumerable<ExpandoObject> InvoiceDtosForRead, MetaData metaData)> GetInvoices(InvoiceParams invoiceParams)
    {
        var pagedListResults = await _invoiceRepository.
            GetInvoicesAsync(invoiceParams);
        var metaData = pagedListResults.MetaData;
        var dtos = _mapper.Map<IEnumerable<InvoiceDtoForRead>>(pagedListResults);
        var dataShaper = dataShaperOfInvoiceDtoForRead.ShapeData(dtos, invoiceParams.Fields);
        return (dataShaper, metaData);
    }

    public async Task UpdateInvoiceAsync(Guid id, bool trackChanges, InvoiceDtoForUpdate invoiceDtoForUpdate)
    {
        Invoice invoice = await CheckAndReturnInvoiceAsync(id, trackChanges);
        _mapper.Map(invoiceDtoForUpdate, invoice);
        await _invoiceRepository.UpdateInvoiceAsync(invoice);
    }

    private async Task<Invoice> CheckAndReturnInvoiceAsync(Guid id, bool trackChanges)
    {
        var result = await _invoiceRepository.GetInvoiceByConditionAsync(a => a.Id.Equals(id), trackChanges);

        if (result is null)
            throw new InvoiceNotFoundException(id);

        return result;
    }
}
