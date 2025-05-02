using System;
using System.Linq.Expressions;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task CreateAsync(About banner);
    }
}

