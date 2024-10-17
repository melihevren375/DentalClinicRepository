using Entities.Concretes;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Concretes.EfCore.Repository_Extensions;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.Concretes.EfCore.Repos;

public class DentistRepository : BaseRepository<Dentist>, IDentistRepository
{
    public DentistRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task CreateDentistAsync(Dentist dentist) => await CreateEntityAsync(dentist);

    public async Task DeleteDentistAsync(Dentist dentist) => await DeleteEntityAsync(dentist);

    public async Task<Dentist> GetDentistByConditionAsync(Expression<Func<Dentist, bool>> expression, bool trackChanges)
    {
        var results = await GetEntitiesByCondition(expression, trackChanges).SingleOrDefaultAsync();
        return results;
    }

    public async Task<PagedList<Dentist>> GetDentistsAsync(DentistParams dentistParams)
    {
        var results = await GetEntities(dentistParams).
            FilterByBirthDateRange(dentistParams.MinBirthDate, dentistParams.MaxBirthDate).
            FilterByFirstName(dentistParams.FirstName).
            FilterByIsActive(dentistParams.IsActive).
            FilterByLastName(dentistParams.LastName).
            FilterByPhoneNumber(dentistParams.PhoneNumber).
            FilterBySpecialty(dentistParams.Specialty).
            FilterCreatedDate(dentistParams.MinCreatedDate, dentistParams.MaxCreatedDate).ToListAsync();

        return PagedList<Dentist>.ToPagedList(results, dentistParams.PageNumber, dentistParams.PageSize);
    }

    public async Task UpdateDentistAsync(Dentist dentist) => await UpdateEntityAsync(dentist);

}
