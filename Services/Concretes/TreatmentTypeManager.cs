using AutoMapper;
using Entities.Concretes;
using Entities.DataTransferObjects.TreatmentTypeDtos;
using Entities.Exceptions.NotFoundExceptions;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services.Concretes;

public class TreatmentTypeManager : ITreatmentTypeService
{
    private readonly ITreatmentTypeRepository _treatmentTypeRepository;
    private readonly IMapper _mapper;
    private readonly IDataShaper<TreatmentTypeDtoForRead> _dataShaperOfTreatmentTypeDtoForRead;

    public TreatmentTypeManager(ITreatmentTypeRepository treatmentTypeRepository, IMapper mapper, IDataShaper<TreatmentTypeDtoForRead> dataShaperOfTreatmentTypeDtoForRead)
    {
        _treatmentTypeRepository = treatmentTypeRepository;
        _mapper = mapper;
        _dataShaperOfTreatmentTypeDtoForRead = dataShaperOfTreatmentTypeDtoForRead;
    }

    public async Task CreateTreatmentTypeAsync(TreatmentTypeDtoForInsertion treatmentTypeDtoForInsertion)
    {
        TreatmentType treatmentType = _mapper.Map<TreatmentType>(treatmentTypeDtoForInsertion);
        await _treatmentTypeRepository.CreateTreatmentTypeAsync(treatmentType);
    }

    public async Task DeleteTreatmentTypeAsync(Guid id, bool trackChanges)
    {
        TreatmentType treatmentType = await CheckAndReturnTreatmentType(id, trackChanges);
        await _treatmentTypeRepository.DeleteTreatmentTypeAsync(treatmentType);
    }

    public async Task<(IEnumerable<ExpandoObject> TreatmentTypeDtosForRead, MetaData metaData)> GetTreatmentTypes(TreatmentTypeParams treatmentTypeParams)
    {
        var pagedListResults = await _treatmentTypeRepository.
            GetTreatmentTypesAsync(treatmentTypeParams);
        var metaData = pagedListResults.MetaData;
        var dtos = _mapper.Map<IEnumerable<TreatmentTypeDtoForRead>>(pagedListResults);
        var dataShaper = _dataShaperOfTreatmentTypeDtoForRead.ShapeData(dtos, treatmentTypeParams.Fields);
        return (dataShaper, metaData);
    }

    public async Task UpdateTreatmentTypeAsync(Guid id, bool trackChanges, TreatmentTypeDtoForUpdate treatmentTypeDtoForUpdate)
    {
        TreatmentType treatmentType = await CheckAndReturnTreatmentType(id, trackChanges);
        _mapper.Map(treatmentTypeDtoForUpdate, treatmentType);
        await _treatmentTypeRepository.UpdateTreatmentTypeAsync(treatmentType);
    }

    private async Task<TreatmentType> CheckAndReturnTreatmentType(Guid id, bool trackChanges)
    {
        TreatmentType treatmentType = await _treatmentTypeRepository.GetTreatmentTypeByConditionAsync(tt => tt.Id.Equals(id), trackChanges);

        if (treatmentType is null)
            throw new TreatmentTypeNotFoundException(id);

        return treatmentType;
    }
}
