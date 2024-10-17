using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IBaseRepository<T>
    where T : Entity
{
    IQueryable<T> GetEntities(RequestParams requestParams);
    IQueryable<T> GetEntitiesByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    Task CreateEntityAsync(T entity);
    Task UpdateEntityAsync(T entity);
    Task DeleteEntityAsync(T entity);
}
