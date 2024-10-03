using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IClinicalAssistantRepository : IBaseRepository<ClinicalAssistant>
{
    Task<PagedList<ClinicalAssistant>> GetClinicalAssistantsAsync(ClinicalAssistantParams clinicalAssistantParams);
    Task<ClinicalAssistant> GetClinicalAssistantByConditionAsync(Expression<Func<ClinicalAssistant, bool>> expression);
    void CreateClinicalAssistantAsync(ClinicalAssistant clinicalAssistant);
    void DeleteClinicalAssistantAsync(ClinicalAssistant clinicalAssistant);
    void UpdateClinicalAssistantAsync(ClinicalAssistant clinicalAssistant);
}
