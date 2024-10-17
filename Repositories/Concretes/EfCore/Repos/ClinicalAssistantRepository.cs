using Entities.Concretes;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Concretes.EfCore.Repository_Extensions;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.Concretes.EfCore.Repos;

public class ClinicalAssistantRepository : BaseRepository<ClinicalAssistant>, IClinicalAssistantRepository
{
    public ClinicalAssistantRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task CreateClinicalAssistantAsync(ClinicalAssistant clinicalAssistant) => await CreateEntityAsync(clinicalAssistant);

    public async Task DeleteClinicalAssistantAsync(ClinicalAssistant clinicalAssistant) => await DeleteEntityAsync(clinicalAssistant);

    public async Task<ClinicalAssistant> GetClinicalAssistantByConditionAsync(Expression<Func<ClinicalAssistant, bool>> expression, bool trackChanges)
    {
        var result = await GetEntitiesByCondition(expression, trackChanges).
           SingleOrDefaultAsync();

        return result;
    }

    public async Task<PagedList<ClinicalAssistant>> GetClinicalAssistantsAsync(ClinicalAssistantParams clinicalAssistantParams)
    {
        var results = await GetEntities(clinicalAssistantParams).
            FilterByBirthDateRange(clinicalAssistantParams.MinBirthDate, clinicalAssistantParams.MaxBirthDate).
            FilterByFirstName(clinicalAssistantParams.FirstName).
            FilterByIsActive(clinicalAssistantParams.IsActive).
            FilterByLastName(clinicalAssistantParams.LastName).
            FilterByPhoneNumber(clinicalAssistantParams.PhoneNumber).
            FilterBySpecialty(clinicalAssistantParams.Specialty).
            FilterCreatedDate(clinicalAssistantParams.MinCreatedDate, clinicalAssistantParams.MaxCreatedDate).ToListAsync();

        return PagedList<ClinicalAssistant>.ToPagedList(results, clinicalAssistantParams.PageNumber, clinicalAssistantParams.PageSize);
    }

    public async Task UpdateClinicalAssistantAsync(ClinicalAssistant clinicalAssistant) => await UpdateEntityAsync(clinicalAssistant);

}
