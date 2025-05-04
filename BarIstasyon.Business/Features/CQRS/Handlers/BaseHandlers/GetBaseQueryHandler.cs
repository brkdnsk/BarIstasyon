using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.BaseQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.BaseHandlers
{
    public class GetBaseQueryHandler
    {
        private readonly IMongoCollection<Base> _baseCollection;

        public GetBaseQueryHandler(IMongoDatabase database)
        {
            _baseCollection = database.GetCollection<Base>("Bases");
        }

        public async Task<List<Base>> Handle(GetBaseByIdQuery query)
        {
            var baseList = await _baseCollection.Find(_ => true).ToListAsync();
            return baseList;
        }
    }
}
