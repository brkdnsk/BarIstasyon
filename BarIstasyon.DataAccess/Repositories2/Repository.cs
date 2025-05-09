using MongoDB.Bson;
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

        public async Task<T?> GetByIdAsync(Object id)
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

        public async Task RemoveAsync(ObjectId id)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("_id", id);
                var result = await _collection.DeleteOneAsync(filter);

                if (result.DeletedCount == 0)
                {
                    throw new Exception("Silme işlemi başarısız oldu, belge bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Bir hata oluştu: " + ex.Message);
            }
        }
        public async Task UpdateAsync(ObjectId id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            var updateResult = await _collection.ReplaceOneAsync(filter, entity);
            if (updateResult.MatchedCount == 0)
            {
                throw new Exception("Belge bulunamadı, güncelleme yapılmadı.");
            }

            if (updateResult.ModifiedCount == 0)
            {
                throw new Exception("Güncellenmiş veri yok. Veriler zaten aynı.");
            }
        }


    }
}