using System;
using System.Threading.Tasks;
using BookStore.Business.Interfaces;
using BookStore.Data.Context;
using BookStore.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repository
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {

        public ProviderRepository(BookStoreDbContext context) : base(context)
        {

        }

        public async Task<Provider> GetProviderAddress(Guid id)
        {
            return await _context.Providers.AsNoTracking()
            .Include(p => p.Address)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Provider> GetProviderProductcAddress(Guid id)
        {
            return await _context.Providers.AsNoTracking()
            .Include(p => p.Products)
            .Include(p => p.Address)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}