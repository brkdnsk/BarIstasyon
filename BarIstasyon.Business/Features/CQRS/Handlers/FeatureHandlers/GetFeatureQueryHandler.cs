using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Queries;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;


namespace BarIstasyon.Business.Features.CQRS.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler
    {
        private readonly IMongoCollection<Feature> _featureCollection;

        public GetFeatureQueryHandler(IMongoDatabase database)
        {
            _featureCollection = database.GetCollection<Feature>("Features");
        }

        public async Task<List<Feature>> Handle(GetFeatureByIdQuery query)
        {
            var contactList = await _featureCollection.Find(_ => true).ToListAsync();
            return contactList;
        }
    }
}
