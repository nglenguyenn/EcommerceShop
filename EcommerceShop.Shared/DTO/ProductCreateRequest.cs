using Microsoft.AspNetCore.Http;
using System;

namespace EcommerceShop.Shared.DTO
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile Images { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CategoryId { get; set; }
    }
}
