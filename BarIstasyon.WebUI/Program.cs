using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver; // MongoDB için gerekli using
using BarIstasyon.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using BarIstasyon.DataAccess.Abstract;
using BarIstasyon.DataAccess.EntityFramework;
using BarIstasyon.Business.Abstract;
using BarIstasyon.Business.Concrete;
using BarIstasyon.DataAccess.Repositories;
using BarIstasyon.WebUI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// MongoDB bağlantısını oluştur
var configuration = builder.Configuration;
var mongoConnectionString = configuration.GetConnectionString("MongoConnection");
var databaseName = configuration["DatabaseName"];

var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(databaseName);

// Eğer MongoDB'yi Dependency Injection ile kullanacaksan:

builder.Services.AddDbContext<CoffeeContext>(option =>
{

    option.UseMongoDB(mongoDatabase.Client, mongoDatabase.DatabaseNamespace.DatabaseName);

});

builder.Services.AddSingleton<IMongoClient>(mongoClient);
builder.Services.AddSingleton<IMongoDatabase>(mongoDatabase);

// Add services to the container.
builder.Services.AddScoped<IBannerDal, EfBannerDal>();
builder.Services.AddScoped<IBannerService, BannerManager>();

builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IBaseDal, EfBaseDal>();
builder.Services.AddScoped<IBaseService, BaseManager>();

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<ICoffeeDal, EfCoffeeDal>();
builder.Services.AddScoped<ICoffeeService, CoffeeManager>();

builder.Services.AddScoped<ICoffeeDescriptionDal, EfCoffeeDescriptionDal>();
builder.Services.AddScoped<ICoffeeDescriptionService, CoffeeDescriptionManager>();

builder.Services.AddScoped<ICoffeeFeatureDal, EfCoffeeFeatureDal>();
builder.Services.AddScoped<ICoffeeFeatureService, CoffeeFeatureManager>();

builder.Services.AddScoped<ICoffeePricingDal, EfCoffeePricingDal>();
builder.Services.AddScoped<ICoffeePricingService, CoffeePricingManager>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();

builder.Services.AddScoped<IFooterAddressDal, EfFooterAddressDal>();
builder.Services.AddScoped<IFooterAddressService, FooterAddressManager>();

builder.Services.AddScoped<ILocationDal, EfLocationDal>();
builder.Services.AddScoped<ILocationService, LocationManager>();

builder.Services.AddScoped<IPricingDal, EfPricingDal>();
builder.Services.AddScoped<IPricingService,PricingManager>();

builder.Services.AddScoped<IServiceDal, EfServiceDal>();
builder.Services.AddScoped<IServiceService>();

builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));








builder.Services.AddServiceExtensions();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
