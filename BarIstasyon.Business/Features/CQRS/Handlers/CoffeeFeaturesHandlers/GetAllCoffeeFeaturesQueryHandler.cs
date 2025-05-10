using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.CoffeeFeaturesQueries;


namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeFeaturesHandlers
{
    public class GetAllCoffeeFeaturesQueryHandler
    {
        private readonly IMongoCollection<CoffeeFeature> _coffeeFeatureCollection;

        public GetAllCoffeeFeaturesQueryHandler(IMongoDatabase database)
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
