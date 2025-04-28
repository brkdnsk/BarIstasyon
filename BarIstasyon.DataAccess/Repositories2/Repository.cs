using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BarIstasyon.DataAccess.Repositories2
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public Repository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task CreateAsync(T entity)
        {
            try
            {
                await _collection.InsertOneAsync(entity);
            }
            catch (Exception ex)
            {
                // Loglama yapılabilir, exception yönetimi
                throw new InvalidOperationException("Bir hata oluştu: " + ex.Message);
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                return await _collection.Find(Builders<T>.Filter.Empty).ToListAsync();
            }
            catch (Exception ex)
            {
                // Loglama yapılabilir, exception yönetimi
                throw new InvalidOperationException("Bir hata oluştu: " + ex.Message);
            }
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                var result = await _collection.Find(Builders<T>.Filter.Where(filter)).SingleOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                // Loglama yapılabilir, exception yönetimi
                throw new InvalidOperationException("Bir hata oluştu: " + ex.Message);
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("_id", id);
                var result = await _collection.Find(filter).SingleOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                // Loglama yapılabilir, exception yönetimi
                throw new InvalidOperationException("Bir hata oluştu: " + ex.Message);
            }
        }

        public async Task RemoveAsync(T entity)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("_id", entity);
                await _collection.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                // Loglama yapılabilir, exception yönetimi
                throw new InvalidOperationException("Bir hata oluştu: " + ex.Message);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("_id", entity);
                await _collection.ReplaceOneAsync(filter, entity);
            }
            catch (Exception ex)
            {
                // Loglama yapılabilir, exception yönetimi
                throw new InvalidOperationException("Bir hata oluştu: " + ex.Message);
            }
        }
    }
}
