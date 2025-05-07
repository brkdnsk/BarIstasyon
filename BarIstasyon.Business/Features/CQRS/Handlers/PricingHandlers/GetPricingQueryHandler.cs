using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Queries;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;


namespace BarIstasyon.Business.Features.CQRS.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler
    {
        private readonly IMongoCollection<Pricing> _pricingCollection;

        public GetPricingQueryHandler(IMongoDatabase database)
        {
            _pricingCollection = database.GetCollection<Pricing>("Pricings");
        }

        public async Task<List<Pricing>> Handle(GetFeatureByIdQuery query)
        {
            var locationList = await _pricingCollection.Find(_ => true).ToListAsync();
            return locationList;
        }
    }
}
