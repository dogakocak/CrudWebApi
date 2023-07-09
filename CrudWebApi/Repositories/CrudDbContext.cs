using Microsoft.EntityFrameworkCore;
using WebApplication3.Config;
using WebApplication3.Models;

namespace WebApplication3.Repositories;

public class CrudDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    
    public CrudDbContext(DbContextOptions options) :
        base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfig());
    }
}