using BarIstasyon.Entity.Entities;
using MongoDB.Driver;

using BarIstasyon.Business.Features.CQRS.Queries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler
    {
        private readonly IMongoCollection<Service> _serviceCollection;

        public GetServiceByIdQueryHandler(IMongoDatabase database)
        {
            _serviceCollection = database.GetCollection<Service>("Services");
        }

        public async Task<Service> Handle(GetServiceByIdQuery query)
        {
            // Burada query.Id artık ObjectId türünde
            var filter = Builders<Service>.Filter.Eq(a => a.ServiceID, query.Id);  // ObjectId ile filtreleme

            var contact = await _serviceCollection.Find(filter).FirstOrDefaultAsync();

            if (contact == null)
            {
                throw new Exception("Servis kaydı bulunamadı.");
            }

            return contact;
        }

    }
}