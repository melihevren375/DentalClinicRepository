using Entities.DataTransferObjects.TreatmentTypeDtos;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts;

public interface ITreatmentTypeService
{
    Task CreateTreatmentTypeAsync(TreatmentTypeDtoForInsertion treatmentTypeDtoForInsertion);
    Task DeleteTreatmentTypeAsync(Guid id, bool trackChanges);
    Task UpdateTreatmentTypeAsync(Guid id, bool trackChanges, TreatmentTypeDtoForUpdate treatmentTypeDtoForUpdate);
    Task<(IEnumerable<ExpandoObject> TreatmentTypeDtosForRead, MetaData metaData)> GetTreatmentTypes(TreatmentTypeParams treatmentTypeParams);
}
