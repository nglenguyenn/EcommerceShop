using EcommerceShop.CustomerSite.Services.CategoryClient;
using EcommerceShop.CustomerSite.Services.ProductClient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceShop.CustomerSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productClient;
        private readonly ICategoryApiClient _categoryClient;
        public ProductController(IProductApiClient productClient, ICategoryApiClient categoryClient)
        {
            _productClient = productClient;
            _categoryClient = categoryClient;
        }
        public async Task<IActionResult> Index(string id)
        {
            var categories = await _categoryClient.GetCategories();
            ViewBag.Categorys = categories;

            if (id != null)
            {
                var productByCate = await _productClient.GetProductByCategory(id);
                ViewBag.Products = productByCate;
            }
            else
            {
                var products = await _productClient.GetProducts();
                ViewBag.Products = products;
            }

            return View();
        }

        public async Task<IActionResult> Detail(string id)
        {
            var product = await _productClient.GetProductById(id);

            var productsSameCate = await _productClient.GetProductSameCategory(id);
            ViewBag.ProductsSameCate = productsSameCate;

            return View(product);
        }
    }
}
