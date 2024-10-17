using Entities.Concretes;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Concretes.EfCore.Repository_Extensions;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.Concretes.EfCore.Repos;

public class EmployeeTypeRepository : BaseRepository<EmployeeType>, IEmployeeTypeRepository
{
    public EmployeeTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task CreateEmployeeTypeAsync(EmployeeType employeeType) => await CreateEntityAsync(employeeType);

    public async Task DeleteEmployeeTypeAsync(EmployeeType employeeType) => DeleteEntityAsync(employeeType);

    public async Task<EmployeeType> GetEmployeeTypeByConditionAsync(Expression<Func<EmployeeType, bool>> expression, bool trackChanges)
    {
        var result = await GetEntitiesByCondition(expression, trackChanges).
            SingleAsync();

        return result;
    }

    public async Task<PagedList<EmployeeType>> GetEmployeeTypesAsync(EmployeeTypeParams employeeTypeParams)
    {
        var results = await GetEntities(employeeTypeParams).
            FilterByName(employeeTypeParams.Name).
            FilterCreatedDate(employeeTypeParams.MinCreatedDate, employeeTypeParams.MaxCreatedDate).
            ToListAsync();

        return PagedList<EmployeeType>.ToPagedList(results, employeeTypeParams.PageNumber, employeeTypeParams.PageSize);
    }

    public async Task UpdateEmployeeTypeAsync(EmployeeType employeeType) => await UpdateEntityAsync(employeeType);

}
