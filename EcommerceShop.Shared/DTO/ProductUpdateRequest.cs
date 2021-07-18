using Microsoft.AspNetCore.Http;
using System;

namespace EcommerceShop.Shared.DTO
{
    public class ProductUpdateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Images { get; set; }
        public IFormFile ThumbnailImages { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CategoryId { get; set; }
    }
}
