using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface ITreatmentDetailsRepository:IBaseRepository<TreatmentType>
{
    Task<PagedList<TreatmentDetails>> GetTreatmentDetailssAsync(TreatmentDetailsParams treatmentDetailsParams);
    Task<TreatmentDetails> GetTreatmentDetailsByConditionAsync(Expression<Func<TreatmentDetails, bool>> expression);
    void CreateTreatmentDetailsAsync(TreatmentDetails treatmentDetails);
    void DeleteTreatmentDetailsAsync(TreatmentDetails treatmentDetails);
    void UpdateTreatmentDetailsAsync(TreatmentDetails treatmentDetails);
}
