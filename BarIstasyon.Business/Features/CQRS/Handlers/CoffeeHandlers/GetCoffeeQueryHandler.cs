using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.CoffeeQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeHandlers
{
    public class GetCoffeeQueryHandler
    {
        private readonly IMongoCollection<Coffee> _coffeeCollection;

        public GetCoffeeQueryHandler(IMongoDatabase database)
        {
            _coffeeCollection = database.GetCollection<Coffee>("Coffees");
        }

        public async Task<List<Coffee>> Handle(GetCoffeeByIdQuery query)
        {
            var coffeeList = await _coffeeCollection.Find(_ => true).ToListAsync();
            return coffeeList;
        }
    }
}
