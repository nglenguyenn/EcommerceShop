using AutoMapper;
using EcommerceShop.BackEnd.Models;
using EcommerceShop.Shared.DTO;

namespace EcommerceShop.Test.Mappings
{
    public static class ProductMapper
    {
        public static IMapper Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductDto, Product>().ForPath(p => p.Category.NameCategory, pm => pm.MapFrom(o => o.NameCategory)).ReverseMap();
                c.CreateMap<ProductCreateRequest, Product>().ReverseMap();
                c.CreateMap<ProductUpdateRequest, Product>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
