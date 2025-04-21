using System;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.DataAccess.Context;
using BarIstasyon.DataAccess.Repositories;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.DataAccess.EntityFramework
{
	public class EfCoffeeDescriptionDal : GenericRepository<CoffeeDescription>, ICoffeeDescriptionDal
	{
        public EfCoffeeDescriptionDal(CoffeeContext context) : base(context)
        {

        }
    }
}

