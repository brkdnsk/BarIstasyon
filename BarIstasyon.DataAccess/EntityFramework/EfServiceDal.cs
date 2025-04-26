using System;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.DataAccess.Context;
using BarIstasyon.DataAccess.Repositories;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.DataAccess.EntityFramework
{
	public class EfServiceDal : GenericRepository<Base>, IBaseDal
	{
        public EfServiceDal(CoffeeContext context) : base(context)
        {

        }
    }
}

