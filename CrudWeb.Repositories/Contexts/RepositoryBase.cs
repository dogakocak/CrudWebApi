using System.Linq.Expressions;
using Repositories.Contracts;

namespace Repositories.Contexts;

public class RepositoryBase<T> : IRepositoryBase<T>
where T: class
{
    
    public IQueryable<T> FindAll(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> FindByConditions(Expression<Func<T, bool>> exp, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void Create(T entity)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }
}