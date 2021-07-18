using EcommerceShop.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceShop.CustomerSite.ViewComponents
{
    public class ReviewViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ReviewDto review)
        {
            return await Task.FromResult(View("Default", review));
        }
    }
}
