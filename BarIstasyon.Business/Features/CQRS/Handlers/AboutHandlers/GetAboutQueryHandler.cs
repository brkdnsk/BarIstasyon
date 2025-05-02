using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.BannerQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IMongoCollection<About> _aboutCollection;

        public GetAboutQueryHandler(IMongoDatabase database)
        {
            _aboutCollection = database.GetCollection<About>("Abouts");
        }

        public async Task<List<About>> Handle(GetAboutByIdQuery query)
        {
            var aboutList = await _aboutCollection.Find(_ => true).ToListAsync();
            return aboutList;
        }
    }
}
