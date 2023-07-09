using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Models;

namespace WebApplication3.Config;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Razer Blackwidow",
                Description = "Mekanik Klavye",
                Price = 1800,
                inStock = true
            }
        );
    }
}