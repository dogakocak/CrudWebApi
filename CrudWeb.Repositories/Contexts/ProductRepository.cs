using CrudWeb.Models.Products;
using Repositories.Contracts;

namespace Repositories.Contexts;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(CrudDbContext crudDbContext) : base(crudDbContext)
    {
    }

    public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges)
        .OrderBy(p => p.Name);

    public Product GetProductById(Guid id, bool trackChanges) =>
        FindByConditions(p => p.Id == id, trackChanges).SingleOrDefault();

    public void CreateOneProduct(Product product) => Create(product);

    public void UpdateOneProduct(Product product) => Update(product);

    public void DeleteOneProduct(Product product) => Delete(product);
}