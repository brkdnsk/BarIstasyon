using System;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.DataAccess.Context;
using BarIstasyon.DataAccess.Repositories;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.DataAccess.EntityFramework
{
	public class EfCoffeePricingDal: GenericRepository<CoffeePricing>,ICoffeePricingDal
	{
        public EfCoffeePricingDal(CoffeeContext context) : base(context)
        {

        }
    }
}

