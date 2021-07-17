using EcommerceShop.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommerceShop.CustomerSite.Services.ProductClient
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly HttpClient _client;

        public ProductApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<ProductDto>> GetProducts()
        {
            var response = await _client.GetAsync("api/products");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductDto>>();
        }

        public async Task<ProductDto> GetProductById(string id)
        {
            var response = await _client.GetAsync("api/product/getproductbyid/" + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ProductDto>();
        }

        public async Task<IList<ProductDto>> GetProductSameCategory(string id)
        {
            var response = await _client.GetAsync("api/product/getproductsamecategory/" + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductDto>>();
        }
        public async Task<IList<ProductDto>> GetProductByCategory(string id)
        {
            var response = await _client.GetAsync("api/product/getproductbycategory/" + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductDto>>();
        }
    }
}
