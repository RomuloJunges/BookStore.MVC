using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.MVC.Models;

namespace BookStore.Business.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByProvider(Guid providerId);
        Task<IEnumerable<Product>> GetProductsProviders();
        Task<Product> GetProductProvider(Guid id);
    }
}