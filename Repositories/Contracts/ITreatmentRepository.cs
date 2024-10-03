using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface ITreatmentRepository:IBaseRepository<Treatment>
{
    Task<PagedList<Treatment>> GetTreatmentsAsync(TreatmentParams treatmentParams);
    Task<Treatment> GetTreatmentByConditionAsync(Expression<Func<Treatment, bool>> expression);
    void CreateTreatmentAsync(Treatment treatment);
    void DeleteTreatmentAsync(Treatment treatment);
    void UpdateTreatmentAsync(Treatment treatment);
}
