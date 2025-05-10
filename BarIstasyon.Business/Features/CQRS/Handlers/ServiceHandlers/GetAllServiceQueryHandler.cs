using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.ServiceQueries;
namespace BarIstasyon.Business.Features.CQRS.Handlers.ServiceHandlers
{
    public class GetAllServiceQueryHandler
    {
        private readonly IMongoCollection<Service> _ServiceCollection;

        public GetAllServiceQueryHandler(IMongoDatabase database)
        {
            _ServiceCollection = database.GetCollection<Service>("Services");
        }

        public async Task<List<Service>> Handle(GetAllServiceQuery query)
        {
            var ServiceList = await _ServiceCollection.Find(_ => true).ToListAsync();
            return ServiceList;
        }
    }
}
