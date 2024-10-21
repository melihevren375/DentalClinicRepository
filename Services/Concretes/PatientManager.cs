using AutoMapper;
using Entities.Concretes;
using Entities.DataTransferObjects.PatientDtos;
using Entities.Exceptions.NotFoundExceptions;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services.Concretes;

public class PatientManager : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    private readonly IDataShaper<PatientDtoForRead> _dataShaperOfPatientDtoForRead;

    public PatientManager(IPatientRepository patientRepository, IMapper mapper, IDataShaper<PatientDtoForRead> dataShaperOfPatientDtoForRead)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
        _dataShaperOfPatientDtoForRead = dataShaperOfPatientDtoForRead;
    }

    public async Task CreatePatientAsync(PatientDtoForInsertion patientDtoForInsertion)
    {
        Patient patient = _mapper.Map<Patient>(patientDtoForInsertion);
        await _patientRepository.CreatePatientAsync(patient);
    }

    public async Task DeletePatientAsync(Guid id, bool trackChanges)
    {
        Patient patient = await CheckAndReturnPatientAsync(id, trackChanges);
        await _patientRepository.DeletePatientAsync(patient);
    }

    public async Task<(IEnumerable<ExpandoObject> patientDtosForRead, MetaData metaData)> GetPatients(PatientParams patientParams)
    {
        var pagedListResults = await _patientRepository.GetPatientsAsync(patientParams);
        var metaData = pagedListResults.MetaData;
        var dtos = _mapper.Map<IEnumerable<PatientDtoForRead>>(pagedListResults);
        var dataShaper = _dataShaperOfPatientDtoForRead.ShapeData(dtos, patientParams.Fields);
        return (dataShaper, metaData);
    }

    public async Task UpdatePatientAsync(Guid id, bool trackChanges, PatientDtoForUpdate patientDtoForUpdate)
    {
        Patient patient = await CheckAndReturnPatientAsync(id, trackChanges);
        _mapper.Map(patientDtoForUpdate, patient);
        await _patientRepository.UpdatePatientAsync(patient);
    }

    private async Task<Patient> CheckAndReturnPatientAsync(Guid id, bool trackChanges)
    {
        var result = await _patientRepository.GetPatientByConditionAsync(a => a.Id.Equals(id), trackChanges);

        if (result is null)
            throw new PatientNotFoundException(id);

        return result;
    }
}
