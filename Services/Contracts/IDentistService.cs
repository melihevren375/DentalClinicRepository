using Entities.DataTransferObjects.DentistDtos;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts;

public interface IDentistService
{
    Task CreateDentistAsync(DentistDtoForInsertion dentistDtoForInsertion);
    Task DeleteDentistAsync(Guid id, bool trackChanges);
    Task UpdateDentistAsync(Guid id, bool trackChanges, DentistDtoForUpdate dentistDtoForUpdate);
    Task<(IEnumerable<ExpandoObject> dentistDtosForRead, MetaData metaData)> GetDentists(DentistParams dentistParams);
}
