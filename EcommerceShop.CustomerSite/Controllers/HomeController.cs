using EcommerceShop.CustomerSite.Models;
using EcommerceShop.CustomerSite.Services.CategoryClient;
using EcommerceShop.CustomerSite.Services.ProductClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EcommerceShop.CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryApiClient _categoryClient;
        private readonly IProductApiClient _productClient;
        private readonly ActivitySource activitySource = new ActivitySource("FrontendSource");

        public HomeController(ILogger<HomeController> logger, ICategoryApiClient categoryClient, IProductApiClient productClient)
        {
            _logger = logger;
            _categoryClient = categoryClient;
            _productClient = productClient;
        }

        public async Task<IActionResult> Index()
        {
            using var activity = activitySource.StartActivity("starting to get products");
            activity?.AddTag("service", "frontend");
            _logger.LogInformation("test login with activity aware");

            var categories = await _categoryClient.GetCategories();
            ViewBag.Categories = categories;

            var products = await _productClient.GetProducts();
            ViewBag.Products = products;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
