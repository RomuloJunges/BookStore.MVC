using System;
using System.Threading.Tasks;
using BookStore.MVC.Models;

namespace BookStore.Business.Interfaces
{
    public interface IProviderRepository : IRepository<Provider>
    {
        Task<Provider> GetProviderByAddress(Guid id);
        Task<Provider> GetProviderProductcAddress(Guid id);
    }
}