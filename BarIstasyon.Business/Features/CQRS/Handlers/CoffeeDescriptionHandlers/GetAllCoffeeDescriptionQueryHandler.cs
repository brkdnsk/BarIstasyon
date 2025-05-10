using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.BaseQueries;
using BarIstasyon.Business.Features.CQRS.Queries.BaseQueries;
using BarIstasyon.Business.Features.CQRS.Queries.CoffeeDescriptionQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeDescriptionHandlers
{
    public class GetAllCoffeeDescriptionQueryHandler
    {
        private readonly IMongoCollection<CoffeeDescription> _coffeeDescriptionCollection;

        public GetAllCoffeeDescriptionQueryHandler(IMongoDatabase database)
        {
            _coffeeDescriptionCollection = database.GetCollection<CoffeeDescription>("CoffeeDescriptions");
        }

        public async Task<List<CoffeeDescription>> Handle(GetAllCoffeeDescriptionQuery query)
        {
            var coffeeDescriptionList = await _coffeeDescriptionCollection.Find(_ => true).ToListAsync();
            return coffeeDescriptionList;
        }
    }
}
