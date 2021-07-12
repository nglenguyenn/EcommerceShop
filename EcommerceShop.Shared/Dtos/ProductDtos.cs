using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceShop.Shared.Dtos
{
    public class ProductDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public CategoryDtos Category { get; set; }
    }
}
