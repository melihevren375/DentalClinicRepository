using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface ITreatmentDetailsRepository : IBaseRepository<TreatmentType>
{
    Task<PagedList<TreatmentDetail>> GetTreatmentDetailssAsync(TreatmentDetailsParams treatmentDetailsParams);
    Task<TreatmentDetail> GetTreatmentDetailsByConditionAsync(Expression<Func<TreatmentDetail, bool>> expression, bool trackChanges);
    Task CreateTreatmentDetailsAsync(TreatmentDetail treatmentDetail);
    Task DeleteTreatmentDetailsAsync(TreatmentDetail treatmentDetail);
    Task UpdateTreatmentDetailsAsync(TreatmentDetail treatmentDetail);
}
