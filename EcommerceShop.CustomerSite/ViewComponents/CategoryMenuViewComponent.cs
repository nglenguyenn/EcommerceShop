using EcommerceShop.CustomerSite.Services.CategoryClient;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceShop.CustomerSite.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryApiClient _categoryApiClient;

        public CategoryMenuViewComponent(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categorys = await _categoryApiClient.GetCategories();

            return View(categorys);
        }
    }
}
