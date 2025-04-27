using System;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Concrete
{
    public class FooterAddressManager : GenericManager<FooterAddress>, IFooterAddressService
    {
        public FooterAddressManager(IGenericDal<FooterAddress> genericDal) : base(genericDal)
        {
        }
    }
}

