using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.AboutCommands;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries.BannerQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IMongoCollection<Banner> _bannerCollection;

        public GetBannerByIdQueryHandler(IMongoDatabase database)
        {
            _bannerCollection = database.GetCollection<Banner>("Banner");
        }

        public async Task<Banner> Handle(GetBannerByIdQuery query)
        {
            // Burada query.Id artık ObjectId türünde
            var filter = Builders<Banner>.Filter.Eq(a => a.BannerID, query.Id);  // ObjectId ile filtreleme

            var about = await _bannerCollection.Find(filter).FirstOrDefaultAsync();

            if (about == null)
            {
                throw new Exception("About kaydı bulunamadı.");
            }

            return about;
        }

    }
}
