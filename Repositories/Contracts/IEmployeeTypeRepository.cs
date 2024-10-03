using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IEmployeeTypeRepository : IBaseRepository<EmployeeType>
{
    Task<PagedList<EmployeeType>> GetEmployeeTypesAsync(EmployeeTypeParams employeeTypeParams);
    Task<EmployeeType> GetEmployeeTypeByConditionAsync(Expression<Func<EmployeeType, bool>> expression);
    void CreateEmployeeTypeAsync(EmployeeType employeeType);
    void DeleteEmployeeTypeAsync(EmployeeType employeeType);
    void UpdateEmployeeTypeAsync(EmployeeType employeeType);
}
