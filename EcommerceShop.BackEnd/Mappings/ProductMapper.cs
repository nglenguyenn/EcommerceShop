using AutoMapper;
using EcommerceShop.BackEnd.Models;
using EcommerceShop.Shared.DTO;

namespace EcommerceShop.BackEnd.Mappings
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductDto, Product>()
                .ForPath(p => p.Category.NameCategory,
                pm => pm.MapFrom(o => o.NameCategory)).ReverseMap();
            CreateMap<ProductCreateRequest, Product>().ReverseMap();
            CreateMap<ProductUpdateRequest, Product>().ReverseMap();
        }
    }
}
