using Entities.Concretes;
using Entities.RequestFeatures;
using Extensions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.Concretes.EfCore.Repos;

public class TreatmentTypeRepository : BaseRepository<TreatmentType>, ITreatmentTypeRepository
{
    public TreatmentTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task CreateTreatmentTypeAsync(TreatmentType treatmentType)
        => await CreateEntityAsync(treatmentType);

    public async Task DeleteTreatmentTypeAsync(TreatmentType treatmentType)
        => await DeleteEntityAsync(treatmentType);

    public async Task<TreatmentType> GetTreatmentTypeByConditionAsync(Expression<Func<TreatmentType, bool>> expression, bool trackChanges)
    {
        var result = await GetEntitiesByCondition(expression, trackChanges).
            SingleOrDefaultAsync();

        return result;
    }

    public async Task<PagedList<TreatmentType>> GetTreatmentTypesAsync(TreatmentTypeParams treatmentTypeParams)
    {
        var results = await GetEntities(treatmentTypeParams).
            FilterByName(treatmentTypeParams.NameContains).
            FilterByPriceRange(treatmentTypeParams.MinPrice, treatmentTypeParams.MaxPrice).
            FilterCreatedDate(treatmentTypeParams.MinCreatedDate, treatmentTypeParams.MaxCreatedDate).
            ToListAsync();

        return PagedList<TreatmentType>.ToPagedList(results, treatmentTypeParams.PageNumber, treatmentTypeParams.PageSize);
    }

    public async Task UpdateTreatmentTypeAsync(TreatmentType treatmentType)
        => await UpdateEntityAsync(treatmentType);
}
