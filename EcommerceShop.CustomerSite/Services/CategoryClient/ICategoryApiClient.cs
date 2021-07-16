using EcommerceShop.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceShop.CustomerSite.Services.CategoryClient
{
    public interface ICategoryApiClient
    {
        Task<IList<CategoryDto>> GetCategories();
    }
}
