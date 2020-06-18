using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopAPI.Contracts;
using System.Linq.Expressions;
using EShopAPI.Models;
using EShopAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace EShopAPI.Repositories
{
    public class AsyncGenericRepository<T> : IAsyncGenericRepository<T> where T : BaseEntity
    {
        protected readonly EShopAPI_DBContext _context;
        private IMemoryCache _cache;
        public AsyncGenericRepository(EShopAPI_DBContext context , IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public Task<int> CountAll() => _context.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate) => _context.Set<T>().CountAsync();

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public Task<T> GetById(int id)
        {
            var cache = _cache.Get<T>(id);
            if (cache != null)
            {
                //   return cache;
                return null;
            }
            else
            {
                 var get= _context.Set<T>().FindAsync(id);

                var cacheOption = new MemoryCacheEntryOptions().
                    SetSlidingExpiration(TimeSpan.FromSeconds(60));
                _cache.Set(get.Id, get, cacheOption);

                return get;
            }
          
        }
        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        public Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }
        public Task Update(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
