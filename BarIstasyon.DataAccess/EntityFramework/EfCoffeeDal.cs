using System;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.DataAccess.Context;
using BarIstasyon.DataAccess.Repositories;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.DataAccess.EntityFramework
{
	public class EfCoffeeDal : GenericRepository<Coffee>,ICoffeeDal
	{
        public EfCoffeeDal(CoffeeContext context) : base(context)
        {

        }
    }
}

