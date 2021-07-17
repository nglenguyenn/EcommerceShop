using EcommerceShop.BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceShop.BackEnd.Data.SeedData
{
    public static class CategoryDataInitializer
    {
        public static void SeedCategoryData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = "1",
                    NameCategory = "Test Category 1",
                    Description= "Test Category 1",
                    Images="",
                },
                new Category
                {
                    CategoryId = "2",
                    NameCategory = "Test Category 2",
                    Description = "Test Category 2",
                    Images = "",
                },
                new Category
                {
                    CategoryId = "3",
                    NameCategory = "Test Category 3",
                    Description = "Test Category 3",
                    Images = "",
                },
                new Category
                {
                    CategoryId = "4",
                    NameCategory = "Test Category 4",
                    Description = "Test Category 4",
                    Images = "",
                },
                new Category
                {
                    CategoryId = "5",
                    NameCategory = "Test Category 5",
                    Description = "Test Category 5",
                    Images = "",
                });
        }
    }
}
