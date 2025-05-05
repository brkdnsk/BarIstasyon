using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeCommands;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries.CoffeeQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCoffeeByIdQueryHandler
    {
        private readonly IMongoCollection<Coffee> _coffeeCollection;

        public GetCoffeeByIdQueryHandler(IMongoDatabase database)
        {
            _coffeeCollection = database.GetCollection<Coffee>("Coffees");
        }

        public async Task<Coffee> Handle(GetCoffeeByIdQuery query)
        {
            // Burada query.Id artık ObjectId türünde
            var filter = Builders<Coffee>.Filter.Eq(a => a.CoffeeId, query.Id);  // ObjectId ile filtreleme

            var coffee= await _coffeeCollection.Find(filter).FirstOrDefaultAsync();

            if (coffee == null)
            {
                throw new Exception("Coffee kaydı bulunamadı.");
            }

            return coffee;
        }

    }
}