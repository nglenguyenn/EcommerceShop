using EcommerceShop.BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceShop.BackEnd.Data.SeedData
{
    public static class ProductDataInitializer
    {
        public static void SeedProductData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = "1",
                    Name = "Iphone 12 pro max",
                    Description = "Iphone 12 pro max",
                    Price = 20000000,
                    CreatedDate = System.DateTime.Today,
                    CategoryId = "1",
                    Images= "Iphone12promax .jpg"
                },             
                new Product
                {
                    ProductId = "2",
                    Name = "Iphone 11 pro max",
                    Description = "Iphone 11 pro max",
                    Price = 15000000,
                    CreatedDate = System.DateTime.Today,
                    CategoryId = "1",
                    Images= "Iphone11promax .jpg"
                },
                new Product
                {
                    ProductId = "3",
                    Name = "Samsung Galaxy S21 5G",
                    Description = "Test Product 3",
                    Price = 15000000,
                    CreatedDate = System.DateTime.Today,
                    CategoryId = "2",
                    Images = "samsungs21.jpg"
                },
                new Product
                {
                    ProductId = "4",
                    Name = "Samsung Galaxy Note 20",
                    Description = "Samsung Galaxy Note 20",
                    Price = 15000000,
                    CreatedDate = System.DateTime.Today,
                    CategoryId = "2",
                    Images="samsungnote20.jpg"
                },
                new Product
                {
                    ProductId = "5",
                    Name = "Sony Xperia 1 II",
                    Description = "Sony Xperia 1 II",
                    Price = 15000000,
                    CreatedDate = System.DateTime.Today,
                    CategoryId = "3",
                    Images = "sony1ii.png"
                },
                new Product
                {
                    ProductId = "6",
                    Name = "Xiaomi Redmi Note 10 pro",
                    Description = "Xiaomi Redmi Note 10 pro",
                    Price = 15000000,
                    CreatedDate = System.DateTime.Today,
                    CategoryId = "4",
                    Images= "xiaomi-redmi-note-10-pro_2_2.png"
                });
        }
    }
}
