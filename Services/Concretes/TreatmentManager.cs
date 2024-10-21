using AutoMapper;
using Entities.Concretes;
using Entities.DataTransferObjects.TreatmentDtos;
using Entities.Exceptions.NotFoundExceptions;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services.Concretes;

public class TreatmentManager : ITreatmentService
{
    private readonly ITreatmentRepository _treatmentRepository;
    private readonly IMapper _mapper;
    private readonly IDataShaper<TreatmentDtoForRead> _dataShaperOfTreatmentDtoForRead;

    public TreatmentManager(ITreatmentRepository treatmentRepository, IMapper mapper, IDataShaper<TreatmentDtoForRead> dataShaperOfTreatmentDtoForRead)
    {
        _treatmentRepository = treatmentRepository;
        _mapper = mapper;
        _dataShaperOfTreatmentDtoForRead = dataShaperOfTreatmentDtoForRead;
    }

    public async Task CreateTreatmentAsync(TreatmentDtoForInsertion treatmentDtoForInsertion)
    {
        Treatment treatment = _mapper.Map<Treatment>(treatmentDtoForInsertion);
        await _treatmentRepository.CreateTreatmentAsync(treatment);
    }

    public async Task DeleteTreatmentAsync(Guid id, bool trackChanges)
    {
        Treatment treatment = await CheckAndReturnTreatment(id, trackChanges);
        await _treatmentRepository.DeleteTreatmentAsync(treatment);
    }

    public async Task<(IEnumerable<ExpandoObject> TreatmentDtosForRead, MetaData metaData)> GetTreatments(TreatmentParams treatmentParams)
    {
        var pagedListResults = await _treatmentRepository.GetTreatmentsAsync(treatmentParams);
        var metaData = pagedListResults.MetaData;
        var dtos = _mapper.Map<IEnumerable<TreatmentDtoForRead>>(pagedListResults);
        var dataShaper = _dataShaperOfTreatmentDtoForRead.ShapeData(dtos, treatmentParams.Fields);
        return (dataShaper, metaData);
    }

    public async Task UpdateTreatmentAsync(Guid id, bool trackChanges, TreatmentDtoForUpdate treatmentDtoForUpdate)
    {
        Treatment treatment = await CheckAndReturnTreatment(id, trackChanges);
        _mapper.Map(treatmentDtoForUpdate, treatment);
        await _treatmentRepository.UpdateTreatmentAsync(treatment);
    }

    private async Task<Treatment> CheckAndReturnTreatment(Guid id, bool trackChanges)
    {
        Treatment treatment = await _treatmentRepository.GetTreatmentByConditionAsync(t => t.Id.Equals(id), trackChanges);

        if (treatment is null)
            throw new TreatmentNotFoundException(id);

        return treatment;
    }
}
