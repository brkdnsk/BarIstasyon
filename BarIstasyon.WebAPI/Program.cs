using BarIstasyon.Business.Features.CQRS.Handlers.AboutHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.BannerHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.BaseHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.CategoryHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeDescriptionHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeFeatureHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeFeaturesHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.ContactHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.FeatureHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.FooterAddressHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.LocationHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.PricingHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.ServiceHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.SocialMediaHandlers;
using BarIstasyon.Business.Features.CQRS.Queries.CoffeeFeaturesQueries;

using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Swagger (API dokümantasyonu)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDB Bağlantısı
builder.Services.AddSingleton<IMongoClient>(new MongoClient(builder.Configuration.GetConnectionString("MongoConnection")));
builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var dbName = builder.Configuration.GetValue<string>("DatabaseName");
    return client.GetDatabase(dbName);
});

// Generic Repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// About koleksiyonu için repository
builder.Services.AddScoped<IRepository<About>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new Repository<About>(db, "Abouts");
});
builder.Services.AddScoped<IRepository<Banner>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new Repository<Banner>(db, "Banners");
});
builder.Services.AddScoped<IRepository<Base>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new Repository<Base>(db, "Bases");
});
builder.Services.AddScoped<IRepository<Category>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new Repository<Category>(db, "Categories");
});
builder.Services.AddScoped<IRepository<Coffee>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new Repository<Coffee>(db, "Coffees");
});
builder.Services.AddScoped<IRepository<CoffeeDescription>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new Repository<CoffeeDescription>(db, "Coffee Descriptions");
});
builder.Services.AddScoped<IRepository<CoffeeFeature>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new Repository<CoffeeFeature>(db, "Coffee Features");
});
builder.Services.AddScoped<IRepository<Contact>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new Repository<Contact>(db, "Coffee Features");
});
builder.Services.AddScoped<IRepository<Feature>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new Repository<Feature>(db, "Features");
});
builder.Services.AddScoped<IRepository<FooterAddress>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new Repository<FooterAddress>(db, "Footer Address");
}); builder.Services.AddScoped<IRepository<Location>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new Repository<Location>(db, "Location");
});
builder.Services.AddScoped<IRepository<Pricing>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new Repository<Pricing>(db, "Pricings");
});
builder.Services.AddScoped<IRepository<Service>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new Repository<Service>(db, "Services");
}); builder.Services.AddScoped<IRepository<SocialMedia>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new Repository<SocialMedia>(db, "SocialMedias");
});
// Handler servisleri
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<GetAllAboutQueryHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();





builder.Services.AddScoped<CreateBannerCommandsHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<GetAllBannerQueryHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();


builder.Services.AddScoped<CreateBaseCommandHandler>();
builder.Services.AddScoped<UpdateBaseCommandHandler>();
builder.Services.AddScoped<GetAllBaseQueryHandler>();
builder.Services.AddScoped<RemoveBaseCommandHandler>();
builder.Services.AddScoped<GetBaseByIdQueryHandler>();


builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<GetAllCategoryQueryHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();


builder.Services.AddScoped<CreateCoffeeCommandHandler>();
builder.Services.AddScoped<UpdateCoffeeCommandHandler>();
builder.Services.AddScoped<GetAllCoffeeQueryHandler>();
builder.Services.AddScoped<RemoveCoffeeCommandHandler>();
builder.Services.AddScoped<GetCoffeeByIdQueryHandler>();


builder.Services.AddScoped<CreateCoffeeDescriptionCommandHandler>();
builder.Services.AddScoped<UpdateCoffeeDescriptionCommandHandler>();
builder.Services.AddScoped<GetAllCoffeeDescriptionQueryHandler>();
builder.Services.AddScoped<RemoveCoffeeDescriptionCommandHandler>();
builder.Services.AddScoped<GetCoffeeDescriptionByIdQueryHandler>();


builder.Services.AddScoped<CreateCoffeeFeatureCommandHandler>();
builder.Services.AddScoped<UpdateCoffeeFeatureCommandHandler>();
builder.Services.AddScoped<GetAllCoffeeFeaturesQueryHandler>();
builder.Services.AddScoped<RemoveCoffeeFeatureCommandHandler>();
builder.Services.AddScoped<GetCoffeeFeatureByIdQueryHandler>();


builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<GetAllContactQueryHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();


builder.Services.AddScoped<CreateFeatureCommandHandler>();
builder.Services.AddScoped<UpdateFeatureCommandHandler>();
builder.Services.AddScoped<GetAllFeatureQueryHandler>();
builder.Services.AddScoped<RemoveFeatureCommandHandler>();
builder.Services.AddScoped<GetFeatureByIdQueryHandler>();


builder.Services.AddScoped<CreateFooterAddressCommandHandler>();
builder.Services.AddScoped<UpdateFooterAddressCommandHandler>();
builder.Services.AddScoped<GetAllFooterAddressQueryHandler>();
builder.Services.AddScoped<RemoveFooterAddressCommandHandler>();
builder.Services.AddScoped<GetFooterAddressByIdQueryHandler>();


builder.Services.AddScoped<CreateLocationCommandHandler>();
builder.Services.AddScoped<UpdateLocationCommandHandler>();
builder.Services.AddScoped<GetAllLocationQueryHandler>();
builder.Services.AddScoped<RemoveLocationCommandHandler>();
builder.Services.AddScoped<GetLocationByIdQueryHandler>();


builder.Services.AddScoped<CreatePricingCommandHandler>();
builder.Services.AddScoped<UpdatePricingCommandHandler>();
builder.Services.AddScoped<GetAllPricingQueryHandler>();
builder.Services.AddScoped<RemovePricingCommandHandler>();
builder.Services.AddScoped<GetPricingByIdQueryHandler>();


builder.Services.AddScoped<CreateServiceCommandHandler>();
builder.Services.AddScoped<UpdateServiceCommandHandler>();
builder.Services.AddScoped<GetAllServiceQueryHandler>();
builder.Services.AddScoped<RemoveServiceCommandHandler>();
builder.Services.AddScoped<GetServiceByIdQueryHandler>();


builder.Services.AddScoped<CreateSocialMediaCommandHandler>();
builder.Services.AddScoped<UpdateSocialMediaCommandHandler>();
builder.Services.AddScoped<GetAllSocialMediaQueryHandler>();
builder.Services.AddScoped<RemoveSocialMediaCommandHandler>();
builder.Services.AddScoped<GetSocialMediaByIdQueryHandler>();




// Controller servisleri
builder.Services.AddControllers();

var app = builder.Build();

// Geliştirme ortamında Swagger kullan
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers(); // 🔥 Web API için bu şart

app.Run();
