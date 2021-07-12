using EcommerceShop.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceShop.BackEnd.Repositories
{
    interface IProductRepository
    {
        Task<Product> GetItemAsync(Guid id);
        Task<IEnumerable<Product>> GetItemsAsync();
        Task CreateItemAsync(Product product);
        Task UpdateItemAsync(Product product);
        Task DeleteItemAsync(Guid id);
    }
}
