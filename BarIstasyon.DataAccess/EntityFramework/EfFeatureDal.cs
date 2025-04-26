using System;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.DataAccess.Context;
using BarIstasyon.DataAccess.Repositories;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.DataAccess.EntityFramework
{
	public class EfFeatureDal :GenericRepository<Base> ,IBaseDal
	{
        public EfFeatureDal(CoffeeContext context) : base(context)
        {

        }
    }
}

