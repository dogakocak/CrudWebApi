using AutoMapper;
using CrudWeb.Models.Products;
using CrudWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace WebApplication3.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : Controller
{
    private readonly IServiceManager _manager;
    private readonly IMapper _mapper;

    public ProductController(IServiceManager manager, IMapper mapper)
    {
        _mapper = mapper;
        _manager = manager;
    }

    [HttpGet("")]
    public IActionResult GetAllProducts()
    {
        var products = _manager.ProductService.GetAllProducts(false);
        var productsVm = _mapper.Map<List<Product>, List<ProductVm>>(products.ToList());

        return Ok(productsVm);
    }
    [HttpGet("/{id}")]
    public IActionResult GetProductById([FromRoute(Name = "id")] Guid id)
    {
        var product = _manager.ProductService.GetOneProductById(id,false);

        if (product is null)
        {
            return NotFound();
        }

        var productVm = _mapper.Map<Product, ProductVm>(product);

        return Ok(productVm);
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

            _manager.ProductService.CreateOneProduct(product);
            
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
        try
        {
            var product = _manager.ProductService.GetOneProductById(id, false);

            _manager.ProductService.DeleteOneProduct(product, false);
            return Ok(new
            {
                Message = "Product deleted succesfully",
                Product = product
            });
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    [HttpPut("/{id}")]
    public IActionResult UpdateProductById([FromRoute(Name = "id")] Guid id, 
        [FromBody] ProductRm productRm)
    {
        var product = _manager.ProductService.GetOneProductById(id, true);
        
        if (product is null)
        {
            return NotFound();
        }

        product.Name = productRm.Name; //TODO AutoMapper Implementation
        product.Description = productRm.Description;
        product.Price = productRm.Price;
        product.inStock = productRm.inStock;
        
        _manager.ProductService.UpdateOneProduct(id,product,true);
        return Ok(new
        {
            Message = "Product is updated succesfully.",
            Product = product
        });
    }
    
    [HttpGet("count")] 
    public IActionResult GetProductsCount()
    {
        var products = _manager.ProductService.GetAllProducts(false);
        
        return Ok(products.Count());
    }




}