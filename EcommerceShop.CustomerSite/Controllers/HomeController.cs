using EcommerceShop.CustomerSite.Models;
using EcommerceShop.CustomerSite.Services;
using EcommerceShop.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceShop.CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryApiClient _categoryClient;
        private readonly ActivitySource activitySource = new ActivitySource("FrontendSource");
        public HomeController(ILogger<HomeController> logger, ICategoryApiClient categoryClient)
        {
            _logger = logger;
            _categoryClient = categoryClient;
        }

        public async Task<IActionResult> Index()
        {
            var categorys = await _categoryClient.GetCategories();
            ViewBag.Category = categorys;

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
