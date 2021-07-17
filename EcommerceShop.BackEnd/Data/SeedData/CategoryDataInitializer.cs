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
                    NameCategory = "Apple",
                    Description = "Apple Inc",
                    Images = "Apple.png",
                },
                new Category
                {
                    CategoryId = "2",
                    NameCategory = "SamSung",
                    Description = "SamSung Inc",
                    Images = "Samsung.png",
                },
                new Category
                {
                    CategoryId = "3",
                    NameCategory = "Sony",
                    Description = "Sony Inc",
                    Images = "Sony.png",
                },
                new Category
                {
                    CategoryId = "4",
                    NameCategory = "Xiaomi",
                    Description = "Xiaomi Inc",
                    Images = "Xiaomi.png",
                });
        }
    }
}
