using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.BannerQueries;
using BarIstasyon.Business.Features.CQRS.Queries.BannerQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.BannerHandlers
{
    public class GetAllBannerQueryHandler
    {
        private readonly IMongoCollection<Banner> _bannerCollection;

        public GetAllBannerQueryHandler(IMongoDatabase database)
        {
            _bannerCollection = database.GetCollection<Banner>("Banners");
        }

        public async Task<List<Banner>> Handle(GetAllBannerQuery query)
        {
            var bannerList = await _bannerCollection.Find(_ => true).ToListAsync();
            return bannerList;
        }
    }
}
