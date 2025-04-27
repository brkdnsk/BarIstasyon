using System;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Concrete
{
    public class AboutManager : GenericManager<About>, IAboutService
    {
        public AboutManager(IGenericDal<About> genericDal) : base(genericDal)
        {
        }
    }
}

