using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceShop.BackEnd.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Image { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }      
    }
}