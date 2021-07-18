using EcommerceShop.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceShop.CustomerSite.Services.ProductClient
{
    public interface IProductApiClient
    {
        Task<IList<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(string id);
        Task<IList<ProductDto>> GetProductSameCategory(string id);
        Task<IList<ProductDto>> GetProductByCategory(string id);
        Task<IList<ReviewDto>> GetReviews(string id);
        Task<ReviewCreateRequest> PostReview(ReviewCreateRequest reviewcreateRequest);
    }
}
