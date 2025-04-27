using System;
using BarIstasyon.Business.Abstract;
using BarIstasyon.Business.Concrete;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.DataAccess.EntityFramework;
using BarIstasyon.DataAccess.Repositories;

namespace BarIstasyon.WebUI.Extensions
{
	public static class ServiceExtensions
	{
        
            public static void AddServiceExtensions(this IServiceCollection Services)
            {
                Services.AddScoped<IBannerDal, EfBannerDal>();
                Services.AddScoped<IBannerService, BannerManager>();

                Services.AddScoped<IAboutDal, EfAboutDal>();
                Services.AddScoped<IAboutService, AboutManager>();

                Services.AddScoped<IBaseDal, EfBaseDal>();
                Services.AddScoped<IBaseService, BaseManager>();

                Services.AddScoped<ICategoryDal, EfCategoryDal>();
                Services.AddScoped<ICategoryService, CategoryManager>();

                Services.AddScoped<ICoffeeDal, EfCoffeeDal>();
                Services.AddScoped<ICoffeeService, CoffeeManager>();

                Services.AddScoped<ICoffeeDescriptionDal, EfCoffeeDescriptionDal>();
                Services.AddScoped<ICoffeeDescriptionService, CoffeeDescriptionManager>();

                Services.AddScoped<ICoffeeFeatureDal, EfCoffeeFeatureDal>();
                Services.AddScoped<ICoffeeFeatureService, CoffeeFeatureManager>();

                Services.AddScoped<ICoffeePricingDal, EfCoffeePricingDal>();
                Services.AddScoped<ICoffeePricingService, CoffeePricingManager>();

                Services.AddScoped<IContactDal, EfContactDal>();
                Services.AddScoped<IContactService, ContactManager>();

                Services.AddScoped<IFeatureDal, EfFeatureDal>();
                Services.AddScoped<IFeatureService, FeatureManager>();

                Services.AddScoped<IFooterAddressDal, EfFooterAddressDal>();
                Services.AddScoped<IFooterAddressService, FooterAddressManager>();

                Services.AddScoped<ILocationDal, EfLocationDal>();
                Services.AddScoped<ILocationService, LocationManager>();

                Services.AddScoped<IPricingDal, EfPricingDal>();
                Services.AddScoped<IPricingService, PricingManager>();

                Services.AddScoped<IServiceDal, EfServiceDal>();
                Services.AddScoped<IServiceService>();

                Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
                Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            
            }
	}
}

