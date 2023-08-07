using CrudWeb.Models.Products;
using Repositories.Contexts;
using Repositories.Contracts;



public class ProductService : IProductService
{
    private IRepositoryManager _manager;


    public ProductService(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public IEnumerable<Product> GetAllProducts(bool trackChange)
    {
        return _manager.Product.GetAllProducts(trackChange);
    }

    public Product GetOneProductById(Guid id, bool trackChange)
    {
        return _manager.Product.GetProductById(id,trackChange);
    }

    public Product CreateOneProduct(Product product)
    {
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        
        _manager.Product.CreateOneProduct(product);
        _manager.Save();
        return product;
    }

    public void UpdateOneProduct(Guid id, Product product, bool trackChange)
    {
        var entity = _manager.Product.GetProductById(id,trackChange);
        
        if (entity is null)
        {
            throw new Exception($"Product {product.Name} can not be found.");
        }

        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        entity.Name = product.Name;
        entity.Description = product.Description;
        entity.Price = product.Price;
        entity.inStock = product.inStock;
        _manager.Save();
    }

    public void DeleteOneProduct(Product product, bool trackChange)
    {
        var entity = _manager.Product.GetProductById(product.Id,trackChange);

        if (entity is null)
        {
            throw new Exception($"Products {product.Name} can not be found");
        }
        
        _manager.Product.DeleteOneProduct(product);
        _manager.Save();
    }
}