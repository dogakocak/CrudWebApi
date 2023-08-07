using CrudWeb.Models.Products;

namespace Repositories.Contracts;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts(bool trackChange);
    Product GetOneProductById(Guid id, bool trackChange);
    Product CreateOneProduct(Product productRm);
    void UpdateOneProduct(Guid id,Product product, bool trackChange);
    void DeleteOneProduct(Product product, bool trackChange);

}