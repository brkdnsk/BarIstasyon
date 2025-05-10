using BarIstasyon.Business.Features.CQRS.Handlers.AboutHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.BannerHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.BaseHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.CategoryHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeHandlers;
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
