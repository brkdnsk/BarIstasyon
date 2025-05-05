using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.CoffeePricingQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeHandlers
{
    public class GetCoffeePricingQueryHandler
    {
        private readonly IMongoCollection<CoffeePricing> _coffeePricingCollection;

        public GetCoffeePricingQueryHandler(IMongoDatabase database)
        {
            _coffeePricingCollection = database.GetCollection<CoffeePricing>("Coffee Pricings");
        }

        public async Task<List<CoffeePricing>> Handle(GetCoffeePricingByIdQuery query)
        {
            var coffeePricingList = await _coffeePricingCollection.Find(_ => true).ToListAsync();
            return coffeePricingList;
        }
    }
}
