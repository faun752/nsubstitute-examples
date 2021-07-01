using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<T, TId> where TId : IEquatable<TId> where T : class, ITableObject<TId>
    {
        Task<ICollection<T>> GetAll();
        IQueryable<T> GetQueryable();
        Task<T> GetByIdAsync(TId id);
        Task CreateAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(T obj);
        Task ReplaceAsync(T obj);
    }
}
