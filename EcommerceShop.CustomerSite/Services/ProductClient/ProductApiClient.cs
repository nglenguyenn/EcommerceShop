using EcommerceShop.Shared.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
            var response = await _client.GetAsync("api/products/getproductbyid/" + id);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ProductDto>();
        }

        public async Task<IList<ProductDto>> GetProductSameCategory(string id)
        {
            var response = await _client.GetAsync("api/products/getproductsamecategory/" + id);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IList<ProductDto>>();

        }

        public async Task<IList<ProductDto>> GetProductByCategory(string id)
        {
            var response = await _client.GetAsync("api/products/getproductbycategory/" + id);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IList<ProductDto>>();

        }

        public async Task<IList<ReviewDto>> GetReviews(string id)
        {

            var response = await _client.GetAsync("api/reviews/getreviews/" + id);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IList<ReviewDto>>();
        }

        public async Task<ReviewCreateRequest> PostReview(ReviewCreateRequest reviewCreateRequest)
        {
            var json = JsonConvert.SerializeObject(reviewCreateRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/reviews/postreview", data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ReviewCreateRequest>();
        }

    }
}
