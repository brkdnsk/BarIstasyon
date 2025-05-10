using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.LocationQueries;
namespace BarIstasyon.Business.Features.CQRS.Handlers.LocationHandlers
{
    public class GetAllLocationQueryHandler
    {
        private readonly IMongoCollection<Location> _LocationCollection;

        public GetAllLocationQueryHandler(IMongoDatabase database)
        {
            _LocationCollection = database.GetCollection<Location>("Locations");
        }

        public async Task<List<Location>> Handle(GetAllLocationQuery query)
        {
            var LocationList = await _LocationCollection.Find(_ => true).ToListAsync();
            return LocationList;
        }
    }
}
