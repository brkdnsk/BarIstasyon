using BarIstasyon.Entity.Entities;
using MongoDB.Driver;

using BarIstasyon.Business.Features.CQRS.Queries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler
    {
        private readonly IMongoCollection<SocialMedia> _socialMediaCollection;

        public GetSocialMediaByIdQueryHandler(IMongoDatabase database)
        {
            _socialMediaCollection = database.GetCollection<SocialMedia>("Social Medias");
        }

        public async Task<SocialMedia> Handle(GetSocialMediaByIdQuery query)
        {
            // Burada query.Id artık ObjectId türünde
            var filter = Builders<SocialMedia>.Filter.Eq(a => a.SocialMediaID, query.Id);  // ObjectId ile filtreleme

            var contact = await _socialMediaCollection.Find(filter).FirstOrDefaultAsync();

            if (contact == null)
            {
                throw new Exception("Sosyal medya kaydı bulunamadı.");
            }

            return contact;
        }

    }
}