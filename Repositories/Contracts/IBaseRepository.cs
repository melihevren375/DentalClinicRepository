using Entities.Concretes;
using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IBaseRepository<T>
    where T : Entity
{
    IQueryable<T> GetEntities(RequestParams requestParams);
    IQueryable<T> GetEntitiesByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    void CreateEntity(T entity);
    void UpdateEntity(T entity);
    void DeleteEntity(T entity);
}
