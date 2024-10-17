using Entities.Concretes;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.Concretes.EfCore.Repos;

public abstract class BaseRepository<T> : IBaseRepository<T>
    where T : Entity, new()
{
    protected readonly RepositoryContext _repositoryContext;

    public BaseRepository(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    public async Task CreateEntityAsync(T entity)
    {
        await _repositoryContext.Set<T>().AddAsync(entity);
        await _repositoryContext.SaveChangesAsync();
    }

    public async Task DeleteEntityAsync(T entity)
    {
        _repositoryContext.Set<T>().Remove(entity);
        await _repositoryContext.SaveChangesAsync();
    }

    public IQueryable<T> GetEntities(RequestParams requestParams)
    {
        return _repositoryContext.Set<T>().AsNoTracking();
    }

    public IQueryable<T> GetEntitiesByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return !trackChanges
            ? _repositoryContext.Set<T>().Where(expression).AsNoTracking()
            : _repositoryContext.Set<T>().Where(expression);
    }

    public async Task UpdateEntityAsync(T entity)
    {
        _repositoryContext.Set<T>().Update(entity);
        await _repositoryContext.SaveChangesAsync();
    }
}
