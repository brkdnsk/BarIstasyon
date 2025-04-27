using System;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Concrete
{
    public class CoffeePricingManager : GenericManager<CoffeePricing>, ICoffeePricingService
    {
        public CoffeePricingManager(IGenericDal<CoffeePricing> genericDal) : base(genericDal)
        {
        }
    }
}

