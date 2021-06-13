using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookStore.Business.Interfaces;
using BookStore.Data.Context;
using BookStore.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly BookStoreDbContext _context;
        protected readonly DbSet<T> _contextSet;

        public Repository(BookStoreDbContext context)
        {
            _context = context;
            _contextSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate)
        {
            return await _contextSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _contextSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _contextSet.FindAsync(id);
        }

        public virtual async Task Add(T entity)
        {
            _contextSet.Add(entity);
            await SaveChanges();
        }
        public virtual async Task Update(T entity)
        {
            _contextSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remove(Guid id)
        {
            //Create object to remove using ID
            var entity = new T { Id = id };

            _contextSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}