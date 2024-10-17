using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IClinicalAssistantRepository : IBaseRepository<ClinicalAssistant>
{
    Task<PagedList<ClinicalAssistant>> GetClinicalAssistantsAsync(ClinicalAssistantParams clinicalAssistantParams);
    Task<ClinicalAssistant> GetClinicalAssistantByConditionAsync(Expression<Func<ClinicalAssistant, bool>> expression,bool trackChanges);
    Task CreateClinicalAssistantAsync(ClinicalAssistant clinicalAssistant);
    Task DeleteClinicalAssistantAsync(ClinicalAssistant clinicalAssistant);
    Task UpdateClinicalAssistantAsync(ClinicalAssistant clinicalAssistant);
}
