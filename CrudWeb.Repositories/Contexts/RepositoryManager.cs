using Repositories.Contracts;

namespace Repositories.Contexts;

public class RepositoryManager : IRepositoryManager
{

    private readonly CrudDbContext _crudDbContext;
    private readonly Lazy<IProductRepository> _productRepository; // Lazy loading

    public RepositoryManager(CrudDbContext crudDbContext)
    {
        _crudDbContext = crudDbContext;
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(crudDbContext));
    }

    public IProductRepository ProductRepository => _productRepository.Value;

    public void Save() => _crudDbContext.SaveChanges();
}