using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Queries;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;


namespace BarIstasyon.Business.Features.CQRS.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler
    {
        private readonly IMongoCollection<Location> _locationCollection;

        public GetLocationQueryHandler(IMongoDatabase database)
        {
            _locationCollection = database.GetCollection<Location>("Locations");
        }

        public async Task<List<Location>> Handle(GetFeatureByIdQuery query)
        {
            var locationList = await _locationCollection.Find(_ => true).ToListAsync();
            return locationList;
        }
    }
}
