using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.PricingQueries;
namespace BarIstasyon.Business.Features.CQRS.Handlers.PricingHandlers
{
    public class GetAllPricingQueryHandler
    {
        private readonly IMongoCollection<Pricing> _PricingCollection;

        public GetAllPricingQueryHandler(IMongoDatabase database)
        {
            _PricingCollection = database.GetCollection<Pricing>("Pricings");
        }

        public async Task<List<Pricing>> Handle(GetAllPricingQuery query)
        {
            var PricingList = await _PricingCollection.Find(_ => true).ToListAsync();
            return PricingList;
        }
    }
}
