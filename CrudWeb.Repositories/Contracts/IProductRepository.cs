using CrudWeb.Models.Products;

namespace Repositories.Contracts;

public interface IProductRepository : IRepositoryBase<Product>
{

    IQueryable<Product> GetAllProducts(bool trackChanges);
    Product GetProductById(Guid id, bool trackChanges);
    void CreateOneProduct(Product product);
    void UpdateOneProduct(Product product);
    void DeleteOneProduct(Product product);
}