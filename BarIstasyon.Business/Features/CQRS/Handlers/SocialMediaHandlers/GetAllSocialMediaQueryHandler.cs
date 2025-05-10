using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.SocialMediaQueries;
namespace BarIstasyon.Business.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class GetAllSocialMediaQueryHandler
    {
        private readonly IMongoCollection<SocialMedia> _SocialMediaCollection;

        public GetAllSocialMediaQueryHandler(IMongoDatabase database)
        {
            _SocialMediaCollection = database.GetCollection<SocialMedia>("SocialMedias");
        }

        public async Task<List<SocialMedia>> Handle(GetAllSocialMediaQuery query)
        {
            var SocialMediaList = await _SocialMediaCollection.Find(_ => true).ToListAsync();
            return SocialMediaList;
        }
    }
}
