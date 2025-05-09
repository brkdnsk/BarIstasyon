using System;
using System.Linq.Expressions;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;

namespace BarIstasyon.DataAccess.Repositories2
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task CreateAsync(T entity);
        Task UpdateAsync(ObjectId id, T entity);
        Task RemoveAsync(ObjectId id);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}

