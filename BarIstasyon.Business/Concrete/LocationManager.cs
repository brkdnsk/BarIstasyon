using System;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Concrete
{
    public class LocationManager : GenericManager<Banner>, IBannerService
    {
        public LocationManager(IGenericDal<Banner> genericDal) : base(genericDal)
        {
        }
    }
}

