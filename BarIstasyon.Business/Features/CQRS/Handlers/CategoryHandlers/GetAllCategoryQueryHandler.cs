using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.CategoryQueries;
using BarIstasyon.Business.Features.CQRS.Queries.CategoryQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetAllCategoryQueryHandler
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        public GetAllCategoryQueryHandler(IMongoDatabase database)
        {
            _categoryCollection = database.GetCollection<Category>("Categories");
        }

        public async Task<List<Category>> Handle(GetAllCategoryQuery query)
        {
            var categoryList = await _categoryCollection.Find(_ => true).ToListAsync();
            return categoryList;
        }
    }
}
