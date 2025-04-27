using System;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Concrete
{
    public class FeatureManager : GenericManager<Feature>, IFeatureService
    {
        public FeatureManager(IGenericDal<Feature> genericDal) : base(genericDal)
        {
        }
    }
}

