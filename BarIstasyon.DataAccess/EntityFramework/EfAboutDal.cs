using System;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.DataAccess.Context;
using BarIstasyon.DataAccess.Repositories;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.DataAccess.EntityFramework
{
	public class EfAboutDal : GenericRepository <About> , IAboutDal
	{ 
        public EfAboutDal(CoffeeContext context) : base(context)
        {

        }
    }
}

