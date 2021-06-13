using System;
using System.Threading.Tasks;
using BookStore.Business.Interfaces;
using BookStore.Data.Context;
using BookStore.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(BookStoreDbContext context) : base(context)
        {

        }

        public async Task<Address> GetAddressByProvider(Guid providerId)
        {
            return await _context.Addresses.AsNoTracking()
            .FirstOrDefaultAsync(a => a.ProviderId == providerId);
        }
    }
}