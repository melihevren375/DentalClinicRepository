using AutoMapper;
using Entities.Concretes;
using Entities.DataTransferObjects.ClinicalAssistantDtos;
using Entities.Exceptions.NotFoundExceptions;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services.Concretes;

public class ClinicalAssistantManager : IClinicalAsistantService
{
    private readonly IClinicalAssistantRepository _clinicalAssistantRepository;
    private readonly IMapper _mapper;
    private readonly IDataShaper<ClinicalAssistantDtoForRead> _dataShaperOfClinicalAsistantDtoForRead;

    public ClinicalAssistantManager(IClinicalAssistantRepository clinicalAssistantRepository, IMapper mapper, IDataShaper<ClinicalAssistantDtoForRead> dataShaperOfClinicalAsistantDtoForRead)
    {
        _clinicalAssistantRepository = clinicalAssistantRepository;
        _mapper = mapper;
        _dataShaperOfClinicalAsistantDtoForRead = dataShaperOfClinicalAsistantDtoForRead;
    }

    public async Task CreateClinicalAssistantAsync(ClinicalAssistantDtoInsertion clinicalAssistantDtoForInsertion)
    {
        var clinicalAssistant = _mapper.Map<ClinicalAssistant>(clinicalAssistantDtoForInsertion);

        await _clinicalAssistantRepository.CreateClinicalAssistantAsync(clinicalAssistant);
    }

    public async Task DeleteClinicalAssistantAsync(Guid id, bool trackChanges)
    {
        ClinicalAssistant clinicalAssistant = await CheckAndReturnClinicalAssistant(id, trackChanges);

        await _clinicalAssistantRepository.DeleteClinicalAssistantAsync(clinicalAssistant);
    }

    public async Task<(IEnumerable<ExpandoObject> clinicalAssistantDtosForRead, MetaData metaData)> GetClinicalAssistants(ClinicalAssistantParams ClinicalAssistantParams)
    {
        var pagedListResults = await _clinicalAssistantRepository.
            GetClinicalAssistantsAsync(ClinicalAssistantParams);
        var metaData = pagedListResults.MetaData;
        var dtos = _mapper.Map<IEnumerable<ClinicalAssistantDtoForRead>>(pagedListResults);
        var dataShaper = _dataShaperOfClinicalAsistantDtoForRead.ShapeData(dtos, ClinicalAssistantParams.Fields);

        return (clinicalAssistantDtosForRead: dataShaper, MetaData: metaData);
    }

    public async Task UpdateClinicalAssistantAsync(Guid id, bool trackChanges, ClinicalAssistantDtoUpdate ClinicalAssistantDtoForUpdate)
    {
        ClinicalAssistant clinicalAssistant = await CheckAndReturnClinicalAssistant(id, trackChanges);

        _mapper.Map(ClinicalAssistantDtoForUpdate, clinicalAssistant);

        await _clinicalAssistantRepository.UpdateClinicalAssistantAsync(clinicalAssistant);
    }

    private async Task<ClinicalAssistant> CheckAndReturnClinicalAssistant(Guid id, bool trackChanges)
    {
        var result = await _clinicalAssistantRepository.GetClinicalAssistantByConditionAsync(a => a.Id.Equals(id), trackChanges);

        if (result is null)
            throw new ClinicalAssistantNotFoundException(id);

        return result;
    }
}
