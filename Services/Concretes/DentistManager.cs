using AutoMapper;
using Entities.Concretes;
using Entities.DataTransferObjects.DentistDtos;
using Entities.Exceptions.NotFoundExceptions;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services.Concretes;

public class DentistManager : IDentistService
{
    private readonly IDentistRepository _dentistRepository;
    private readonly IMapper _mapper;
    private readonly IDataShaper<DentistDtoForRead> _dataShaperOfDentistDtoForRead;

    public DentistManager(IDentistRepository dentistRepository, IMapper mapper, IDataShaper<DentistDtoForRead> dataShaperOfDentistDtoForRead)
    {
        _dentistRepository = dentistRepository;
        _mapper = mapper;
        _dataShaperOfDentistDtoForRead = dataShaperOfDentistDtoForRead;
    }

    public async Task CreateDentistAsync(DentistDtoForInsertion dentistDtoForInsertion)
    {
        var dentist = _mapper.Map<Dentist>(dentistDtoForInsertion);

        await _dentistRepository.CreateDentistAsync(dentist);
    }

    public async Task DeleteDentistAsync(Guid id, bool trackChanges)
    {
        Dentist dentist = await CheckAndReturnDentist(id, trackChanges);

        await _dentistRepository.DeleteDentistAsync(dentist);
    }

    public async Task<(IEnumerable<ExpandoObject> dentistDtosForRead, MetaData metaData)> GetDentists(DentistParams dentistParams)
    {
        var pagedListResults = await _dentistRepository.
            GetDentistsAsync(dentistParams);

        var metaData = pagedListResults.MetaData;
        var dtos = _mapper.Map<IEnumerable<DentistDtoForRead>>(pagedListResults);
        var dataShaper = _dataShaperOfDentistDtoForRead.ShapeData(dtos, dentistParams.Fields);
        return (dataShaper, metaData);
    }

    public async Task UpdateDentistAsync(Guid id, bool trackChanges, DentistDtoForUpdate dentistDtoForUpdate)
    {
        Dentist dentist = await CheckAndReturnDentist(id, trackChanges);

        _mapper.Map(dentistDtoForUpdate, dentist);

        await _dentistRepository.UpdateDentistAsync(dentist);
    }

    private async Task<Dentist> CheckAndReturnDentist(Guid id, bool trackChanges)
    {
        var result = await _dentistRepository.GetDentistByConditionAsync(a => a.Id.Equals(id), trackChanges);

        if (result is null)
            throw new DentistNotFoundException(id);

        return result;
    }
}
