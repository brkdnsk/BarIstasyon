using System;
using BarIstasyon.Business.Abstract;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Concrete
{
    public class SocialMediaManager : GenericManager<SocialMedia>, ISocialMediaService
    {
        public SocialMediaManager(IGenericDal<SocialMedia> genericDal) : base(genericDal)
        {
        }
    }
}

