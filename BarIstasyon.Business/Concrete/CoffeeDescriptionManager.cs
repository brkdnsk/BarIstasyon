using System;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Concrete
{
    public class CoffeeDescriptionManager : GenericManager<CoffeeDescription>, ICoffeeDescriptionService
    {
        public CoffeeDescriptionManager(IGenericDal<CoffeeDescription> genericDal) : base(genericDal)
        {
        }
    }
}

