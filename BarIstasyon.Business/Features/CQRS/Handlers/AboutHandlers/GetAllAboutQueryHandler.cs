using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.BannerQueries;
using BarIstasyon.Business.Features.CQRS.Queries.AboutQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAllAboutQueryHandler
    {
        private readonly IMongoCollection<About> _aboutCollection;

        public GetAllAboutQueryHandler(IMongoDatabase database)
        {
            _aboutCollection = database.GetCollection<About>("Abouts");
        }

        public async Task<List<About>> Handle(GetAllAboutQuery query)
        {
            var aboutList = await _aboutCollection.Find(_ => true).ToListAsync();
            return aboutList;
        }
    }
}
