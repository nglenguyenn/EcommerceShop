using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Shared.DTO
{
    public class CategoryCreateRequest
    {
        public string NameCategory { get; set; }
        public string Description { get; set; }
        public IFormFile ThumbnailImages { get; set; }
    }
}
