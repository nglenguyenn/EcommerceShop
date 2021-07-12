using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EcommerceShop.BackEnd.Models;
using System.Threading.Tasks;
using System;
using EcommerceShop.Shared.Dtos;

namespace EcommerceShop.BackEnd.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        internal Task Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public DbSet<EcommerceShop.Shared.Dtos.ProductDtos> ProductDtos { get; set; }
    }
}
