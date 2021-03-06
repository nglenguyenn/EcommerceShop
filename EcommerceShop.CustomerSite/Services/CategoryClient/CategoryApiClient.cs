using EcommerceShop.Shared.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcommerceShop.CustomerSite.Services.CategoryClient
{
    public class CategoryApiClient : ICategoryApiClient
    {
        private readonly HttpClient _client;

        public CategoryApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<CategoryDto>> GetCategories()
        {
            var response = await _client.GetAsync("api/categories");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<CategoryDto>>();
        }
    }
}
