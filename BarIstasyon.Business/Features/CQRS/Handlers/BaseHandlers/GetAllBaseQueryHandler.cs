using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.BaseQueries;
using BarIstasyon.Business.Features.CQRS.Queries.BaseQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.BaseHandlers
{
    public class GetAllBaseQueryHandler
    {
        private readonly IMongoCollection<Base> _baseCollection;

        public GetAllBaseQueryHandler(IMongoDatabase database)
        {
            _baseCollection = database.GetCollection<Base>("Bases");
        }

        public async Task<List<Base>> Handle(GetAllBaseQuery query)
        {
            var baseList = await _baseCollection.Find(_ => true).ToListAsync();
            return baseList;
        }
    }
}
