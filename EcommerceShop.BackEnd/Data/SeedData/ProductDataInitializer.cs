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
                    Name = "Test Product 1",
                    Description = "Test Product 1",
                    Price = 100,
                    CreatedDate = System.DateTime.Today,
                    CategoryId = "1",
                },             
                new Product
                {
                    ProductId = "2",
                    Name = "Test Product 2",
                    Description = "Test Product 2",
                    Price = 200,
                    CreatedDate = System.DateTime.Today,
                    CategoryId = "2",
                },
                new Product
                {
                    ProductId = "3",
                    Name = "Test Product 3",
                    Description = "Test Product 3",
                    Price = 500,
                    CreatedDate = System.DateTime.Today,
                    CategoryId = "3",
                },
                new Product
                {
                    ProductId = "4",
                    Name = "Test Product 4",
                    Description = "Test Product 4",
                    Price = 150,
                    CreatedDate = System.DateTime.Today,
                    CategoryId = "4",
                },
                new Product
                {
                    ProductId = "5",
                    Name = "Test Product 5",
                    Description = "Test Product 5",
                    Price = 700,
                    CreatedDate = System.DateTime.Today,
                    CategoryId = "5",
                }, new Product
                {
                    ProductId = "6",
                    Name = "Test Product 6",
                    Description = "Test Product 6",
                    Price = 200,
                    CreatedDate = System.DateTime.Today,
                    CategoryId = "1",
                });
        }
    }
}
