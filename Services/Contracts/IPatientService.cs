using Entities.DataTransferObjects.PatientDtos;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts;

public interface IPatientService
{
    Task CreatePatientAsync(PatientDtoForInsertion patientDtoForInsertion);
    Task DeletePatientAsync(Guid id, bool trackChanges);
    Task UpdatePatientAsync(Guid id, bool trackChanges, PatientDtoForUpdate patientDtoForUpdate);
    Task<(IEnumerable<ExpandoObject> patientDtosForRead, MetaData metaData)> GetPatients(PatientParams patientParams);
}
