using System;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.DataAccess.Context;
using BarIstasyon.DataAccess.Repositories;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.DataAccess.EntityFramework
{
	public class EfSocailMediaDal : GenericRepository<Base>, IBaseDal
	{
        public EfSocailMediaDal(CoffeeContext context) : base(context)
        {

        }
    }
}

