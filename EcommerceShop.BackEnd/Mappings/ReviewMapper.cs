using AutoMapper;
using EcommerceShop.BackEnd.Models;
using EcommerceShop.Shared.DTO;

namespace EcommerceShop.BackEnd.Mappings
{
    public class ReviewMapper : Profile
    {
        public ReviewMapper()
        {
            CreateMap<ReviewDto, Review>().ReverseMap();
            CreateMap<ReviewCreateRequest, Review>().ReverseMap();
        }
    }
}
