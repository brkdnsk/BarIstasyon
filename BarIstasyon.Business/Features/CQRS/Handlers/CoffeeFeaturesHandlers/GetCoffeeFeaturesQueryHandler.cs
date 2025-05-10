using System;
using BarIstasyon.Business.Features.CQRS.Queries.CategoryQueries;
using BarIstasyon.Business.Features.CQRS.Queries.CoffeeFeaturesQueries;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeFeatureHandlers
{
	public class GetCoffeeFeaturesQueryHandler
	{
        private readonly IMongoCollection<CoffeeFeature> _coffeeFeatureCollection;

        public GetCoffeeFeaturesQueryHandler(IMongoDatabase database)
        {
            _coffeeFeatureCollection = database.GetCollection<CoffeeFeature>("Coffee Features");
        }

        public async Task<List<CoffeeFeature>> Handle(GetAllCoffeeFeatureQuery query)
        {
            var coffeeFeatureList = await _coffeeFeatureCollection.Find(_ => true).ToListAsync();
            return coffeeFeatureList;
        }
    }
}

