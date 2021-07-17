using AutoMapper;
using EcommerceShop.BackEnd.Models;
using EcommerceShop.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceShop.BackEnd.Mappings
{
    public class ReviewMapper : Profile
    {
        public  ReviewMapper()
        {
        CreateMap<ReviewDto, Review>().ReverseMap();
        CreateMap<ReviewCreateRequest, Review>().ReverseMap();
        }
    }
}
