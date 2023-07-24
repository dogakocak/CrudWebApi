using CrudWeb.Models.Products;
using Microsoft.EntityFrameworkCore;
using Repositories.Config;

namespace Repositories.Contexts;

public class CrudDbContext : DbContext
{
    public virtual DbSet<Product> Products { get; set; }

    public CrudDbContext(DbContextOptions options) :
        base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfig());
    }
}