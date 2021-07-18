using AutoMapper;
using EcommerceShop.BackEnd.Models;
using EcommerceShop.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Test.Mappings
{
    public static class CategoryMapper
    {
        public static IMapper Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CategoryDto, Category>().ReverseMap();
                c.CreateMap<CategoryCreateRequest, Category>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
