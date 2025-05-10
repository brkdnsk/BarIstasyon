using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.ContactQueries;


namespace BarIstasyon.Business.Features.CQRS.Handlers.ContactHandlers
{
    public class GetAllContactQueryHandler
    {
        private readonly IMongoCollection<Contact> _contactCollection;

        public GetAllContactQueryHandler(IMongoDatabase database)
        {
            _contactCollection = database.GetCollection<Contact>("Contacts");
        }

        public async Task<List<Contact>> Handle(GetAllContactQuery query)
        {
            var contactList = await _contactCollection.Find(_ => true).ToListAsync();
            return contactList;
        }
    }
}
