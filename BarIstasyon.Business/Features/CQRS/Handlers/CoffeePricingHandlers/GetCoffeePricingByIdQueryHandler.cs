using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.CoffeePricingQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeePricingHandlers
{
    public class GetCoffeePricingByIdQueryHandler
    {
        private readonly IMongoCollection<CoffeePricing> _coffeePricingCollection;

        public GetCoffeePricingByIdQueryHandler(IMongoDatabase database)
        {
            _coffeePricingCollection = database.GetCollection<CoffeePricing>("Coffee Pricings");
        }

        public async Task<CoffeePricing> Handle(GetCoffeePricingByIdQuery query)
        {
            // Burada query.Id artık ObjectId türünde
            var filter = Builders<CoffeePricing>.Filter.Eq(a => a.CoffeePricingID, query.Id);  // ObjectId ile filtreleme

            var coffeePricing = await _coffeePricingCollection.Find(filter).FirstOrDefaultAsync();

            if (coffeePricing == null)
            {
                throw new Exception("Kahve Fiyatlandırma kaydı bulunamadı.");
            }

            return coffeePricing;
        }

    }
}