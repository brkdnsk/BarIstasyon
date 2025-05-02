using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.BannerQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IMongoCollection<Banner> _bannerCollection;

        public GetBannerQueryHandler(IMongoDatabase database)
        {
            _bannerCollection = database.GetCollection<Banner>("Banner");
        }

        public async Task<List<Banner>> Handle(GetBannerByIdQuery query)
        {
            var bannerList = await _bannerCollection.Find(_ => true).ToListAsync();
            return bannerList;
        }
    }
}
