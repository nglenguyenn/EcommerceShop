using EcommerceShop.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceShop.CustomerSite.Services.ProductClient
{
    public interface IProductApiClient
    {
        Task<IList<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(string id);
        Task<IList<ProductDto>> GetProductSameCategory(string id);
        Task<IList<ProductDto>> GetProductByCategory(string id);
    }
}
