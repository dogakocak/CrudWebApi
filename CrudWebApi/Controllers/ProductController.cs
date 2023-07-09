using Microsoft.AspNetCore.Mvc;
using Mysqlx;
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
    public IActionResult GetAllProducts()
    {
        var books = _crudDbContext.Products.ToList();
        return Ok(books);
    }
    
    [HttpGet, Route("{id}")]
    public IActionResult GetProductById([FromRoute(Name = "id")]Guid id)
    {
        var book = _crudDbContext.Products
            .FirstOrDefault(product => product.Id.Equals(id));

        if (book is null)
        {
            return NotFound();
        }
        
        return Ok(book);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] ProductRm productRm)
    {
        try
        {
            if (productRm is null)
            {
                return BadRequest();
            }

            Product product = new Product
            {
                Name = productRm.Name,
                Description = productRm.Description,
                Price = productRm.Price,
                inStock = productRm.inStock
            };
            
            _crudDbContext.Products.Add(product);
            _crudDbContext.SaveChanges();
            return StatusCode(201, product);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        
    }
}