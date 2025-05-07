using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Queries;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;


namespace BarIstasyon.Business.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler
    {
        private readonly IMongoCollection<SocialMedia> _socialMediaCollection;

        public GetSocialMediaQueryHandler(IMongoDatabase database)
        {
            _socialMediaCollection = database.GetCollection<SocialMedia>("SocialMedias");
        }

        public async Task<List<SocialMedia>> Handle(GetSocialMediaByIdQuery query)
        {
            var socialMediaList = await _socialMediaCollection.Find(_ => true).ToListAsync();
            return socialMediaList;
        }
    }
}
