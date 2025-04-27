using System;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Concrete
{
    public class PricingManager : GenericManager<Pricing>, IPricingService
    {
        public PricingManager(IGenericDal<Pricing> genericDal) : base(genericDal)
        {
        }
    }
}

