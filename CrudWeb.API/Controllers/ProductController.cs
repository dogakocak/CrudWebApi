using CrudWeb.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace WebApplication3.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : Controller
{
    private readonly IRepositoryManager _manager;

    public ProductController(IRepositoryManager manager)
    {
        _manager = manager;
    }

    [HttpGet("")]
    public IActionResult GetAllProducts()
    {
        var products = _manager.Product.GetAllProducts(false);
        
        return Ok(products);
    }

    [HttpGet("/{id}")]
    public IActionResult GetProductById([FromRoute(Name = "id")] Guid id)
    {
        var product = _manager.Product.GetProductById(id,false);

        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost("")]
    public IActionResult CreateProduct([FromBody] ProductRm productRm)
    {
        try
        {
            if (productRm is null)
            {
                return BadRequest();
            }

            Product product = new Product // TODO AutoMapper Implementation
            {
                Name = productRm.Name,
                Description = productRm.Description,
                Price = productRm.Price,
                inStock = productRm.inStock
            };

            _manager.Product.CreateOneProduct(product);
            _manager.Save();
            
            return StatusCode(201, product);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }

    [HttpDelete("/{id}")]
    public IActionResult DeleteProductById([FromRoute(Name = "id")] Guid id)
    {
        var product = _manager.Product.GetProductById(id,true);

        if (product is null)
        {
            return NotFound();
        }
        _manager.Product.DeleteOneProduct(product);
        _manager.Save();
        return Ok(new
        {
            Message = "Product deleted succesfully",
            Product = product
        });
    }
    
    [HttpPut("/{id}")]
    public IActionResult UpdateProductById([FromRoute(Name = "id")] Guid id, 
        [FromBody] ProductRm productRm)
    {
        var product = _manager.Product.GetProductById(id, true);
        
        if (product is null)
        {
            return NotFound();
        }

        product.Name = productRm.Name; //TODO AutoMapper Implementation
        product.Description = productRm.Description;
        product.Price = productRm.Price;
        product.inStock = productRm.inStock;
        
        _manager.Product.UpdateOneProduct(product);
        _manager.Save();
        return Ok(new
        {
            Message = "Product is updated succesfully.",
            Product = product
        });
    }
    
    [HttpGet("Count")] 
    public IActionResult ProductSize()
    {
        var products = _manager.Product.GetAllProducts(false);
        
        return Ok(products.Count());
    }




}