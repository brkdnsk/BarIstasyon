using System;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Concrete
{
    public class PricingService : GenericManager<Pricing>, IPricingService
    {
        public PricingService(IGenericDal<Pricing> genericDal) : base(genericDal)
        {
        }
    }
}

