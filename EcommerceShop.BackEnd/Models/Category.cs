using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceShop.BackEnd.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}