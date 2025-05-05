using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Queries.CategoryQueries;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;



namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeDescriptionHandlers
{
    public class GetCoffeeDescriptionQueryHandler
    {
        private readonly IMongoCollection<CoffeeDescription> _coffeeDescriptionCollection;

        public GetCoffeeDescriptionQueryHandler(IMongoDatabase database)
        {
            _coffeeDescriptionCollection = database.GetCollection<CoffeeDescription>("Coffee Descriptions");
        }

        public async Task<List<CoffeeDescription>> Handle(GetCoffeeDescriptionByIdQuery query)
        {
            var coffeeDescriptionList = await _coffeeDescriptionCollection.Find(_ => true).ToListAsync();
            return coffeeDescriptionList;
        }
    }
}
