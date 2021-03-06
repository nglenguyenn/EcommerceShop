using AutoMapper;
using EcommerceShop.BackEnd.Models;
using EcommerceShop.Shared.DTO;

namespace EcommerceShop.Test.Mappings
{
    public static class ReviewMapper
    {
        public static IMapper Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ReviewDto, Review>().ReverseMap();
                c.CreateMap<ReviewCreateRequest, Review>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
