using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface ITreatmentTypeRepository : IBaseRepository<TreatmentType>
{
    Task<PagedList<TreatmentType>> GetTreatmentTypesAsync(TreatmentTypeParams treatmentTypeParams);
    Task<TreatmentType> GetTreatmentTypeByConditionAsync(Expression<Func<TreatmentType, bool>> expression,bool trackChanges);
    Task CreateTreatmentTypeAsync(TreatmentType treatmentType);
    Task DeleteTreatmentTypeAsync(TreatmentType treatmentType);
    Task UpdateTreatmentTypeAsync(TreatmentType treatmentType);
}
