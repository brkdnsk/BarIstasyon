using System;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.DataAccess.Context;
using BarIstasyon.Entity.Entities;
using BarIstasyon.DataAccess.Repositories;

namespace BarIstasyon.DataAccess.EntityFramework
{
	public class EfLocationDal: GenericRepository<Location>, ILocationDal
    {
        public EfLocationDal(CoffeeContext context) : base(context)
        {

        }
    }
}

