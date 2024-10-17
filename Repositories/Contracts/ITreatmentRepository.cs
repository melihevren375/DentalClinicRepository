using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface ITreatmentRepository : IBaseRepository<Treatment>
{
    Task<PagedList<Treatment>> GetTreatmentsAsync(TreatmentParams treatmentParams);
    Task<Treatment> GetTreatmentByConditionAsync(Expression<Func<Treatment, bool>> expression, bool trackChanges);
    Task CreateTreatmentAsync(Treatment treatment);
    Task DeleteTreatmentAsync(Treatment treatment);
    Task UpdateTreatmentAsync(Treatment treatment);
}
