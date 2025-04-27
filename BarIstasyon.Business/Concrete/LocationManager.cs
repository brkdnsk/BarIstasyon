using System;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Concrete
{
    public class LocationManager : GenericManager<Location>, ILocationService
    {
        public LocationManager(IGenericDal<Location> genericDal) : base(genericDal)
        {
        }
    }
}

