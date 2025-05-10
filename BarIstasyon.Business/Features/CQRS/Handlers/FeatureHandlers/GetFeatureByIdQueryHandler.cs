using BarIstasyon.Entity.Entities;
using MongoDB.Driver;

using BarIstasyon.Business.Features.CQRS.Queries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler
    {
        private readonly IMongoCollection<Feature> _featureCollection;

        public GetFeatureByIdQueryHandler(IMongoDatabase database)
        {
            _featureCollection = database.GetCollection<Feature>("Features");
        }

        public async Task<Feature> Handle(GetFeatureByIdQuery query)
        {
            // Burada query.Id artık ObjectId türünde
            var filter = Builders<Feature>.Filter.Eq(a => a.FeatureID, query.Id);  // ObjectId ile filtreleme

            var contact = await _featureCollection.Find(filter).FirstOrDefaultAsync();

            if (contact == null)
            {
                throw new Exception("Kahve Fiyatlandırma kaydı bulunamadı.");
            }

            return contact;
        }

    }
}