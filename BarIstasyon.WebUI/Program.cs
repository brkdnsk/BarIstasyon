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
