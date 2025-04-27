using System;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.DataAccess.Context;
using BarIstasyon.DataAccess.Repositories;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.DataAccess.EntityFramework
{
	public class EfPricingDal : GenericRepository<Pricing>, IPricingDal
	{
        public EfPricingDal(CoffeeContext context) : base(context)
        {

        }
    }
}

