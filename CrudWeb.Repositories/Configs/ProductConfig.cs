using CrudWeb.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config;

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