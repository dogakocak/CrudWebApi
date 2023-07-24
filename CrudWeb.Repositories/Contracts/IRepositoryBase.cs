using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IRepositoryBase <T>
{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByConditions(Expression<Func<T, bool>> exp, bool trackChanges);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    
}