using System;
using System.Linq.Expressions;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using MongoDB.Bson;

namespace BarIstasyon.Business.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<int> GetTCountAsync()
        {
            return await _genericDal.CountAsync();
        }

        public async Task TCreateAsync(T entity)
        {
            await _genericDal.CreateAsync(entity);
        }

        public async Task TDeleteAsync(ObjectId id)
        {
            await _genericDal.DeleteAsync(id);
        }

        public async Task<T> TGetByIdAsync(ObjectId id)
        {
            return await _genericDal.GetByIdAsync(id);
        }

        public async Task<List<T>> TGetFilteredListAsync(Expression<Func<T, bool>> Predicate)
        {
            return await _genericDal.GetFilteredListAsync(Predicate);
        }

        public async Task<List<T>> TGetListAsync()
        {
            return await _genericDal.GetListAsync();
        }

        public async Task TUpdateAsync(T entity)
        {
            await _genericDal.UpdateAsync(entity);
        }
    }
}

