using AutoMapper;

namespace CrudWeb.Models.Products;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductVm>();
    }

}