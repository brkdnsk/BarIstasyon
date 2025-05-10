using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.CategoryQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        public GetCategoryQueryHandler(IMongoDatabase database)
        {
            _categoryCollection = database.GetCollection<Category>("Categories");
        }

        public async Task<List<Category>> Handle(GetCategoryByIdQuery query)
        {
            var categoryList = await _categoryCollection.Find(_ => true).ToListAsync();
            return categoryList;
        }
    }
}
