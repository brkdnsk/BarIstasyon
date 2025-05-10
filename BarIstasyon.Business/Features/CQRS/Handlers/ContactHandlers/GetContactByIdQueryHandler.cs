using BarIstasyon.Entity.Entities;
using MongoDB.Driver;

using BarIstasyon.Business.Features.CQRS.Queries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IMongoCollection<Contact> _contactCollection;

        public GetContactByIdQueryHandler(IMongoDatabase database)
        {
            _contactCollection = database.GetCollection<Contact>("Contacts");
        }

        public async Task<Contact> Handle(GetContactByIdQuery query)
        {
            // Burada query.Id artık ObjectId türünde
            var filter = Builders<Contact>.Filter.Eq(a => a.ContactID, query.Id);  // ObjectId ile filtreleme

            var contact = await _contactCollection.Find(filter).FirstOrDefaultAsync();

            if (contact == null)
            {
                throw new Exception("Kahve Fiyatlandırma kaydı bulunamadı.");
            }

            return contact;
        }

    }
}