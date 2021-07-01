using Core.Models.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories.Ef
{
    public abstract class Repository<T, TId> : IRepository<T, TId>
        where TId : IEquatable<TId>
        where T : class, ITableObject<TId>
    {
        protected readonly ApiContext _apiContext;
        private DbSet<T> targetDbSet;

        public Repository(ApiContext context)
        {
            _apiContext = context;
            targetDbSet = context.Set<T>();
        }

        protected Func<ApiContext, DbSet<T>> GetDbSet { get; private set; }

        public async Task<ICollection<T>> GetAll()
        {
            return await targetDbSet.ToListAsync();
        }

        public IQueryable<T> GetQueryable()
        {
            return targetDbSet;
        }

        public async Task<T> GetByIdAsync(TId id)
        {
            return await targetDbSet.FindAsync(id);
        }

        public Task CreateAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceAsync(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
