using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceShop.BackEnd.Models
{
    public class Category
    {
        public string CategoryId { get; set; }
        public string NameCategory { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
