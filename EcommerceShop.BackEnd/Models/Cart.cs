using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceShop.BackEnd.Models
{
    public class Cart
    {
        public int Quantity { set; get; }
        public Product product { set; get; }
    }
}
