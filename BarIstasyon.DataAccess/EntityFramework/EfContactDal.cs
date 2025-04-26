using System;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.DataAccess.Context;
using BarIstasyon.DataAccess.Repositories;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.DataAccess.EntityFramework
{
	public class EfContactDal :GenericRepository<Base>,IBaseDal
	{
        public EfContactDal(CoffeeContext context) : base(context)
        {

        }
    }
}

