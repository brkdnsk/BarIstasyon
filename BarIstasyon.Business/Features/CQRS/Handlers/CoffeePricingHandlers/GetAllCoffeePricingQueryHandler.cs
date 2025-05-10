using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.CoffeePricingQueries;
using BarIstasyon.Business.Features.CQRS.Queries.CoffeePricingQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeePricingHandlers
{
    public class GetAllCoffeePricingQueryHandler
    {
        private readonly IMongoCollection<CoffeePricing> _coffeePricingCollection;

        public GetAllCoffeePricingQueryHandler(IMongoDatabase database)
        {
            _coffeePricingCollection = database.GetCollection<CoffeePricing>("CoffeePricings");
        }

        public async Task<List<CoffeePricing>> Handle(GetAllCoffeePricingQuery query)
        {
            var coffeePricing = await _coffeePricingCollection.Find(_ => true).ToListAsync();
            return coffeePricing;
        }
    }
}
