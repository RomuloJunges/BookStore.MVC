using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Business.Interfaces;
using BookStore.Data.Context;
using BookStore.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(BookStoreDbContext context) : base(context)
        {

        }

        public async Task<Product> GetProductProvider(Guid id)
        {
            return await _context.Products.AsNoTracking().Include(p => p.Provider).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsByProvider(Guid providerId)
        {
            return await Search(p => p.ProviderId == providerId);
        }

        public async Task<IEnumerable<Product>> GetProductsProviders()
        {
            return await _context.Products.AsNoTracking().Include(p => p.Provider).OrderBy(p => p.Name).ToListAsync();
        }
    }
}