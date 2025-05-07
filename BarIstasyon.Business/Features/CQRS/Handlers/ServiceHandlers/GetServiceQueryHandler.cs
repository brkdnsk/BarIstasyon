using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Queries;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;


namespace BarIstasyon.Business.Features.CQRS.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler
    {
        private readonly IMongoCollection<Service> _serviceCollection;

        public GetServiceQueryHandler(IMongoDatabase database)
        {
            _serviceCollection = database.GetCollection<Service>("Services");
        }

        public async Task<List<Service>> Handle(GetServiceByIdQuery query)
        {
            var serviceList = await _serviceCollection.Find(_ => true).ToListAsync();
            return serviceList;
        }
    }
}
