using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.Repositories;

namespace WebApplication3.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : Controller
{
    // GET
    private readonly CrudDbContext _crudDbContext;

    public ProductController(CrudDbContext crudDbContext)
    {
        _crudDbContext = crudDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _crudDbContext.Products
            .AsNoTracking()
            .ToListAsync();
        
        return Ok(products);
    }

    [HttpGet, Route("{id}")]
    public async Task<IActionResult> GetProductById([FromRoute(Name = "id")] Guid id)
    {
        var product = await _crudDbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(product => product.Id.Equals(id));

        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductRm productRm)
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

            await _crudDbContext.Products.AddAsync(product);
            await _crudDbContext.SaveChangesAsync();
            return StatusCode(201, product);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }

    [HttpDelete, Route("{id}")]
    public async Task<IActionResult> DeleteProductById([FromRoute(Name = "id")] Guid id)
    {
        var product = await _crudDbContext.Products
            .FirstOrDefaultAsync(product => product.Id.Equals(id));

        if (product is null)
        {
            return NotFound();
        }

        _crudDbContext.Products.Remove(product);
        await _crudDbContext.SaveChangesAsync();
        return Ok(new
        {
            Message = "Product deleted succesfully",
            Product = product
        });
    }
    
    [HttpPut, Route("{id}")]
    public async Task<IActionResult> UpdateProductById([FromRoute(Name = "id")] Guid id, 
        [FromBody] ProductRm productRm)
    {
        var product = await _crudDbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(product => product.Id.Equals(id));
        
        if (product is null)
        {
            return NotFound();
        }

        product.Name = productRm.Name; //TODO AutoMapper Implementation
        product.Description = productRm.Description;
        product.Price = productRm.Price;
        product.inStock = productRm.inStock;
        
        _crudDbContext.Update(product);
        await _crudDbContext.SaveChangesAsync();
        return Ok(new
        {
            Message = "Product is updated succesfully.",
            Product = product
        });
    }




}