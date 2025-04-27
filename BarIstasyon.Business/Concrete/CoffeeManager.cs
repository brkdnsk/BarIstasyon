using System;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Concrete
{
    public class CoffeeManager : GenericManager<Coffee>, ICoffeeService
    {
        public CoffeeManager(IGenericDal<Coffee> genericDal) : base(genericDal)
        {
        }
    }
}

