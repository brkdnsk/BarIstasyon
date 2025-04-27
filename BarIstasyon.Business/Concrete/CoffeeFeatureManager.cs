using System;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Concrete
{
    public class CoffeeFeatureManager : GenericManager<CoffeeFeature>, ICoffeeFeatureService
    {
        public CoffeeFeatureManager(IGenericDal<CoffeeFeature> genericDal) : base(genericDal)
        {
        }
    }
}

