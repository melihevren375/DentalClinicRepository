using Entities.DataTransferObjects.TreatmentDtos;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts;

public interface ITreatmentService
{
    Task CreateTreatmentAsync(TreatmentDtoForInsertion treatmentDtoForInsertion);
    Task DeleteTreatmentAsync(Guid id, bool trackChanges);
    Task UpdateTreatmentAsync(Guid id, bool trackChanges, TreatmentDtoForUpdate treatmentDtoForUpdate);
    Task<(IEnumerable<ExpandoObject> TreatmentDtosForRead, MetaData metaData)> GetTreatments(TreatmentParams treatmentParams);
}
