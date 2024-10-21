using Entities.DataTransferObjects.TreatmentDetailsDtos;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts;

public interface ITreatmentDetailService
{
    Task CreateTreatmentDetailAsync(TreatmentDetailsDtoForInsertion treatmentDetailDtoForInsertion);
    Task DeleteTreatmentDetailAsync(Guid id, bool trackChanges);
    Task UpdateTreatmentDetailAsync(Guid id, bool trackChanges, TreatmentDetailsDtoForUpdate treatmentDetailDtoForUpdate);
    Task<(IEnumerable<ExpandoObject> TreatmentDetailDtosForRead, MetaData metaData)> GetTreatmentDetails(TreatmentDetailsParams treatmentDetailParams);
}
