using BarIstasyon.Business.Features.CQRS.Handlers.AboutHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.BannerHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.BaseHandlers;
using BarIstasyon.Business.Features.CQRS.Handlers.CategoryHandlers;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Configuration
var configuration = builder.Configuration;
builder.Services.AddSwaggerGen();
// MongoDB Bağlantısı ve Veritabanı Ayarları
builder.Services.AddSingleton<IMongoClient>(new MongoClient(configuration.GetConnectionString("MongoConnection")));
builder.Services.AddScoped<IMongoDatabase>(serviceProvider =>
{
    var client = serviceProvider.GetRequiredService<IMongoClient>();
    var databaseName = configuration.GetValue<string>("DatabaseName"); // DatabaseName ayarını alıyoruz.
    return client.GetDatabase(databaseName); // MongoDB veritabanına bağlantı.
});


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



// Repository ve CommandHandler Servisleri
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<CreateBannerCommandsHandler>();
builder.Services.AddScoped<CreateBaseCommandHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();

builder.Services.AddScoped<IRepository<About>>(serviceProvider =>
{
    var database = serviceProvider.GetRequiredService<IMongoDatabase>();
    return new Repository<About>(database, "Abouts");  // "Abouts" koleksiyon adını belirtin
});
builder.Services.AddScoped<IRepository<Banner>>(serviceProvider =>
{
    var database = serviceProvider.GetRequiredService<IMongoDatabase>();
    return new Repository<Banner>(database, "Banners");  // "Banners" koleksiyon adını belirtin
});
builder.Services.AddScoped<IRepository<Base>>(serviceProvider =>
{
    var database = serviceProvider.GetRequiredService<IMongoDatabase>();
    return new Repository<Base>(database, "Bases");  // "Banners" koleksiyon adını belirtin
});
builder.Services.AddScoped<IRepository<Category>>(serviceProvider =>
{
    var database = serviceProvider.GetRequiredService<IMongoDatabase>();
    return new Repository<Category>(database, "Categories");  // "Banners" koleksiyon adını belirtin
});

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Swagger ve diğer servis yapılandırmaları
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
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
