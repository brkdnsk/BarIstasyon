using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.BaseCommands;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries.BaseQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.BaseHandlers
{
    public class GetBaseByIdQueryHandler
    {
        private readonly IMongoCollection<Base> _baseCollection;

        public GetBaseByIdQueryHandler(IMongoDatabase database)
        {
            _baseCollection = database.GetCollection<Base>("Bases");
        }

        public async Task<Base> Handle(GetBaseByIdQuery query)
        {
            // Burada query.Id artık ObjectId türünde
            var filter = Builders<Base>.Filter.Eq(a => a.BaseID, query.Id);  // ObjectId ile filtreleme

            var about = await _baseCollection.Find(filter).FirstOrDefaultAsync();

            if (about == null)
            {
                throw new Exception("Base kaydı bulunamadı.");
            }

            return about;
        }

    }
}