using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.FeatureQueries;


namespace BarIstasyon.Business.Features.CQRS.Handlers.FeatureHandlers
{
    public class GetAllFeatureQueryHandler
    {
        private readonly IMongoCollection<Feature> _featureCollection;

        public GetAllFeatureQueryHandler(IMongoDatabase database)
        {
            _featureCollection = database.GetCollection<Feature>("Features");
        }

        public async Task<List<Feature>> Handle(GetAllFeatureQuery query)
        {
            var featureList = await _featureCollection.Find(_ => true).ToListAsync();
            return featureList;
        }
    }
}
