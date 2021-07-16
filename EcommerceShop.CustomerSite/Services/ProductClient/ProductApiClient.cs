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
            var response = await _client.GetAsync("api/product");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductDto>>();
        }

    }
}
