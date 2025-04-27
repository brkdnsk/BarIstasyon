using System;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.DataAccess.Context;
using BarIstasyon.DataAccess.Repositories;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.DataAccess.EntityFramework 
{
	public class EfFooterAddressDal: GenericRepository<FooterAddress>,IFooterAddressDal
	{
        public EfFooterAddressDal(CoffeeContext context) : base(context)
        {

        }
    }
}

