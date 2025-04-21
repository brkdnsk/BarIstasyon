using System;
using BarIstasyon.Entity.Entities;
using BarIstasyon.DataAccess.Repositories;
using BarIstasyon.DataAccess.Abstract;
using MongoDB.Bson;
using System.Linq.Expressions;
using BarIstasyon.DataAccess.Context;

namespace BarIstasyon.DataAccess.EntityFramework
{
    public class EfBannerDal : GenericRepository<Banner>, IBannerDal
    {
        public EfBannerDal(CoffeeContext context) : base(context)
        {

        }
    }
}

