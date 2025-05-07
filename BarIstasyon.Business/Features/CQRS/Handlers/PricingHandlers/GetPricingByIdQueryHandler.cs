using BarIstasyon.Entity.Entities;
using MongoDB.Driver;

using BarIstasyon.Business.Features.CQRS.Queries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler
    {
        private readonly IMongoCollection<Pricing> _pricingCollection;

        public GetPricingByIdQueryHandler(IMongoDatabase database)
        {
            _pricingCollection = database.GetCollection<Pricing>("Pricings");
        }

        public async Task<Pricing> Handle(GetPricingByIdQuery query)
        {
            // Burada query.Id artık ObjectId türünde
            var filter = Builders<Pricing>.Filter.Eq(a => a.PricingID, query.Id);  // ObjectId ile filtreleme

            var contact = await _pricingCollection.Find(filter).FirstOrDefaultAsync();

            if (contact == null)
            {
                throw new Exception("Fiyatlandırma kaydı bulunamadı.");
            }

            return contact;
        }

    }
}