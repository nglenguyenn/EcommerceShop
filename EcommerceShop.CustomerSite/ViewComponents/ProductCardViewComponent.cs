using EcommerceShop.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceShop.CustomerSite.ViewComponents
{
    public class ProductCardViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ProductDto product)
        {
            return await Task.FromResult(View("Default", product));
        }
    }
}
