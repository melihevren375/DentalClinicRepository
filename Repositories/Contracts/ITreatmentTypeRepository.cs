using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface ITreatmentTypeRepository : IBaseRepository<TreatmentType>
{
    Task<PagedList<TreatmentType>> GetTreatmentTypesAsync(TreatmentTypeParams treatmentTypeParams);
    Task<TreatmentType> GetTreatmentTypeByConditionAsync(Expression<Func<TreatmentType, bool>> expression);
    void CreateTreatmentTypeAsync(TreatmentType treatmentType);
    void DeleteTreatmentTypeAsync(TreatmentType treatmentType);
    void UpdateTreatmentTypeAsync(TreatmentType treatmentType);
}
