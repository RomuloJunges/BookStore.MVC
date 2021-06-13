using System;
using System.Threading.Tasks;
using BookStore.MVC.Models;

namespace BookStore.Business.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address> GetAddressByProvider(Guid providerId);
    }
}