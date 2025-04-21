using System;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.DataAccess.Context;
using BarIstasyon.DataAccess.Repositories;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.DataAccess.EntityFramework
{
	public class EfBaseDal :GenericRepository<Base>,IBaseDal
	{
        public EfBaseDal(CoffeeContext context) : base(context)
        {

        }
    }
}

