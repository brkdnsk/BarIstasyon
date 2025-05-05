using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Queries;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;


namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IMongoCollection<Contact> _contactCollection;

        public GetContactQueryHandler(IMongoDatabase database)
        {
            _contactCollection = database.GetCollection<Contact>("Contacts");
        }

        public async Task<List<Contact>> Handle(GetContactByIdQuery query)
        {
            var contactList = await _contactCollection.Find(_ => true).ToListAsync();
            return contactList;
        }
    }
}
