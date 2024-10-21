using Entities.DataTransferObjects.ClinicalAssistantDtos;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts
{
    public interface IClinicalAsistantService
    {
        Task CreateClinicalAssistantAsync(ClinicalAssistantDtoInsertion clinicalAssistantDtoForInsertion);
        Task DeleteClinicalAssistantAsync(Guid id, bool trackChanges);
        Task UpdateClinicalAssistantAsync(Guid id, bool trackChanges, ClinicalAssistantDtoUpdate ClinicalAssistantDtoForUpdate);
        Task<(IEnumerable<ExpandoObject> clinicalAssistantDtosForRead, MetaData metaData)> GetClinicalAssistants(ClinicalAssistantParams ClinicalAssistantParams);
    }
}
