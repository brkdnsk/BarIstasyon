using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeDescriptionCommands;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries.CategoryQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeDescriptionHandlers
{
    public class GetCoffeeDescriptionByIdQueryHandler
    {
        private readonly IMongoCollection<CoffeeDescription> _coffeeDescriptionCollection;

        public GetCoffeeDescriptionByIdQueryHandler(IMongoDatabase database)
        {
            _coffeeDescriptionCollection = database.GetCollection<CoffeeDescription>("Coffee Descriptions");
        }

        public async Task<CoffeeDescription> Handle(GetCoffeeDescriptionByIdQuery query)
        {
            // Burada query.Id artık ObjectId türünde
            var filter = Builders<CoffeeDescription>.Filter.Eq(a => a.CoffeeDescriptionID, query.Id);  // ObjectId ile filtreleme

            var about = await _coffeeDescriptionCollection.Find(filter).FirstOrDefaultAsync();

            if (about == null)
            {
                throw new Exception("About kaydı bulunamadı.");
            }

            return about;
        }

    }
}
