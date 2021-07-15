using EcommerceShop.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceShop.CustomerSite.Services
{
    public interface ICategoryApiClient
    {
        Task<IList<CategoryDto>> GetCategory();
    }
}
