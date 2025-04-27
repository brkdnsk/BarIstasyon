using System;
using System.Linq.Expressions;
using MongoDB.Bson;

namespace BarIstasyon.Business.Abstract
{
	public interface IGenericService <T> where T : class
	{
        Task TCreateAsync(T entity);

        Task TUpdateAsync(T entity);

        Task TDeleteAsync(ObjectId id);

        Task<List<T>> TGetListAsync();

        Task<T> TGetByIdAsync(ObjectId id);

        Task<int> GetTCountAsync();
        Task<List<T>> TGetFilteredListAsync(Expression<Func<T, bool>> Predicate);
    }
}

