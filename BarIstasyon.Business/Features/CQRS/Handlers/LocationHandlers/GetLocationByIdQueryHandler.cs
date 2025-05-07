using BarIstasyon.Entity.Entities;
using MongoDB.Driver;

using BarIstasyon.Business.Features.CQRS.Queries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler
    {
        private readonly IMongoCollection<Location> _locationCollection;

        public GetLocationByIdQueryHandler(IMongoDatabase database)
        {
            _locationCollection = database.GetCollection<Location>("Locations");
        }

        public async Task<Location> Handle(GetContactByIdQuery query)
        {
            // Burada query.Id artık ObjectId türünde
            var filter = Builders<Location>.Filter.Eq(a => a.LocationID, query.Id);  // ObjectId ile filtreleme

            var contact = await _locationCollection.Find(filter).FirstOrDefaultAsync();

            if (contact == null)
            {
                throw new Exception("Adres kaydı bulunamadı.");
            }

            return contact;
        }

    }
}