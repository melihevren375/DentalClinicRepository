using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface ITreatmentDetailsRepository : IBaseRepository<TreatmentType>
{
    Task<PagedList<TreatmentDetails>> GetTreatmentDetailssAsync(TreatmentDetailsParams treatmentDetailsParams);
    Task<TreatmentDetails> GetTreatmentDetailsByConditionAsync(Expression<Func<TreatmentDetails, bool>> expression, bool trackChanges);
    Task CreateTreatmentDetailsAsync(TreatmentDetails treatmentDetails);
    Task DeleteTreatmentDetailsAsync(TreatmentDetails treatmentDetails);
    Task UpdateTreatmentDetailsAsync(TreatmentDetails treatmentDetails);
}
