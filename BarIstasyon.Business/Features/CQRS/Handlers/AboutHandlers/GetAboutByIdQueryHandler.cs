using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.AboutCommands;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries.BannerQueries;
using BarIstasyon.Business.Features.CQRS.Queries.AboutQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IMongoCollection<About> _aboutCollection;

        public GetAboutByIdQueryHandler(IMongoDatabase database)
        {
            _aboutCollection = database.GetCollection<About>("Abouts");
        }

        public async Task<About> Handle(GetAboutByIdQuery query)
        {
            // Burada query.Id artık ObjectId türünde
            var filter = Builders<About>.Filter.Eq(a => a.AboutID, query.Id);  // ObjectId ile filtreleme

            var about = await _aboutCollection.Find(filter).FirstOrDefaultAsync();

            if (about == null)
            {
                throw new Exception("About kaydı bulunamadı.");
            }

            return about;
        }

    }
}
