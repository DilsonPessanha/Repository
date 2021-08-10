using AutoMapper;
using Product.Webapi.Models;
using Products.Infrastructure.Model;

namespace Products.Webapi.AutoMapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductInput, ProductObject>();
        }
    }
}
