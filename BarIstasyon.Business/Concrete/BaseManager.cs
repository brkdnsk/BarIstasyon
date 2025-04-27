
using System;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Concrete
{
    public class BaseManager : GenericManager<Base>, IBaseService
    {
        public BaseManager(IGenericDal<Base> genericDal) : base(genericDal)
        {
        }
    }
}

