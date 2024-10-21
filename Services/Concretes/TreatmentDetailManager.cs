using AutoMapper;
using Entities.Concretes;
using Entities.DataTransferObjects.TreatmentDetailsDtos;
using Entities.Exceptions.NotFoundExceptions;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services.Concretes;

public class TreatmentDetailManager : ITreatmentDetailService
{
    private readonly ITreatmentDetailsRepository _treatmentDetailsRepository;
    private readonly IMapper _mapper;
    private readonly IDataShaper<TreatmentDetailDtoForRead> _dataShaperOfTreatmentDetailDtoForRead;

    public TreatmentDetailManager(ITreatmentDetailsRepository treatmentDetailsRepository, IMapper mapper, IDataShaper<TreatmentDetailDtoForRead> dataShaperOfTreatmentDetailDtoForRead)
    {
        _treatmentDetailsRepository = treatmentDetailsRepository;
        _mapper = mapper;
        _dataShaperOfTreatmentDetailDtoForRead = dataShaperOfTreatmentDetailDtoForRead;
    }

    public async Task CreateTreatmentDetailAsync(TreatmentDetailsDtoForInsertion treatmentDetailDtoForInsertion)
    {
        TreatmentDetail treatmentDetail = _mapper.Map<TreatmentDetail>(treatmentDetailDtoForInsertion);
        await _treatmentDetailsRepository.CreateTreatmentDetailsAsync(treatmentDetail);
    }

    public async Task DeleteTreatmentDetailAsync(Guid id, bool trackChanges)
    {
        TreatmentDetail treatmentDetail = await CheckAndReturnTreatmentDetail(id, trackChanges);
        await _treatmentDetailsRepository.DeleteTreatmentDetailsAsync(treatmentDetail);
    }

    public async Task<(IEnumerable<ExpandoObject> TreatmentDetailDtosForRead, MetaData metaData)> GetTreatmentDetails(TreatmentDetailsParams treatmentDetailParams)
    {
        var pagedListResults = await _treatmentDetailsRepository.GetTreatmentDetailssAsync(treatmentDetailParams);
        var metaData = pagedListResults.MetaData;
        var dtos = _mapper.Map<IEnumerable<TreatmentDetailDtoForRead>>(pagedListResults);
        var dataShaper = _dataShaperOfTreatmentDetailDtoForRead.ShapeData(dtos, treatmentDetailParams.Fields);
        return (dataShaper, metaData);
    }

    public async Task UpdateTreatmentDetailAsync(Guid id, bool trackChanges, TreatmentDetailsDtoForUpdate treatmentDetailDtoForUpdate)
    {
        TreatmentDetail treatmentDetail = await CheckAndReturnTreatmentDetail(id, trackChanges);
        _mapper.Map(treatmentDetailDtoForUpdate, treatmentDetail);
        await _treatmentDetailsRepository.UpdateTreatmentDetailsAsync(treatmentDetail);
    }

    private async Task<TreatmentDetail> CheckAndReturnTreatmentDetail(Guid id, bool trackChanges)
    {
        TreatmentDetail treatmentDetail = await _treatmentDetailsRepository.
            GetTreatmentDetailsByConditionAsync(t => t.Id.Equals(id), trackChanges);

        if (treatmentDetail is null)
            throw new TreatmentDetailsNotFoundException(id);

        return treatmentDetail;
    }
}
