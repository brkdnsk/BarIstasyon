using System;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Concrete
{
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        public CategoryManager(IGenericDal<Category> genericDal) : base(genericDal)
        {
        }
    }
}

