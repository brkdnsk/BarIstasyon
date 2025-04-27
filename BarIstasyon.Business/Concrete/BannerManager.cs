using System;
using System.Linq.Expressions;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;

namespace BarIstasyon.Business.Concrete
{
    public class BannerManager : IBannerService
    {
        private readonly IBannerDal _bannerDal;

        public Task<int> GetTCountAsync()
        {
            return _bannerDal.CountAsync();
        }

        public Task TCreateAsync(Banner entity)
        {
            throw new NotImplementedException();
        }

        public Task TDeleteAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task<Banner> TGetByIdAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Banner>> TGetFilteredListAsync(Expression<Func<Banner, bool>> Predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Banner>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task TUpdateAsync(Banner entity)
        {
            throw new NotImplementedException();
        }
    }
}

