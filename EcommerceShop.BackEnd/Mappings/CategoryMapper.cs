using AutoMapper;
using EcommerceShop.BackEnd.Models;
using EcommerceShop.Shared.DTO;

namespace EcommerceShop.BackEnd.Mappings
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CategoryCreateRequest, Category>().ReverseMap();
        }
    }
}
