using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeFeatureCommands;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries.CoffeeFeaturesQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeFeaturesHandlers
{
    public class GetCoffeeFeaturesByIdQueryHandler
    {
        private readonly IMongoCollection<CoffeeFeature> _coffeeFeatureCollection;

        public GetCoffeeFeaturesByIdQueryHandler(IMongoDatabase database)
        {
            _coffeeFeatureCollection = database.GetCollection<CoffeeFeature>("Coffee Features");
        }

        public async Task<CoffeeFeature> Handle(GetCoffeeFeatureByIdQuery query)
        {
            // Burada query.Id artık ObjectId türünde
            var filter = Builders<CoffeeFeature>.Filter.Eq(a => a.CoffeeFeatureID, query.Id);  // ObjectId ile filtreleme

            var coffeeFeature = await _coffeeFeatureCollection.Find(filter).FirstOrDefaultAsync();

            if (coffeeFeature == null)
            {
                throw new Exception("Kahve özellikleri kaydı bulunamadı.");
            }

            return coffeeFeature;
        }

    }
}
