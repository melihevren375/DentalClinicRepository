using Entities.DataTransferObjects.EmployeeTypeDtos;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts;

public interface IEmployeeTypeService
{
    Task CreateEmployeeTypeAsync(EmployeeTypeDtoForInsertion employeeTypeDtoForInsertion);
    Task DeleteEmployeeTypeAsync(Guid id, bool trackChanges);
    Task UpdateEmployeeTypeAsync(Guid id, bool trackChanges, EmployeeTypeDtoForUpdate employeeTypeDtoForUpdate);
    Task<(IEnumerable<ExpandoObject> employeeTypeDtosForRead, MetaData metaData)> GetEmployeeTypes(EmployeeTypeParams employeeTypeParams);
}
