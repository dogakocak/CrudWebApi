using System.Linq.Expressions;
using Repositories.Contracts;

namespace Repositories.Contexts;

public abstract class RepositoryBase<T> : IRepositoryBase<T>
where T: class
{
    protected readonly CrudDbContext CrudDbContext;
    public RepositoryBase(CrudDbContext crudDbContext)
    {
        CrudDbContext = crudDbContext;
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> FindByConditions(Expression<Func<T, bool>> exp, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public void Create(T entity) => CrudDbContext.Set<T>().Add(entity);

    public void Update(T entity) => CrudDbContext.Set<T>().Update(entity);

    public void Delete(T entity) => CrudDbContext.Set<T>().Remove(entity);
}