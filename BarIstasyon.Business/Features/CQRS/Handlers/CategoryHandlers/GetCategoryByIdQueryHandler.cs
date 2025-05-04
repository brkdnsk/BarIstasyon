using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.BaseCommands;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries.CategoryQueries;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        public GetCategoryByIdQueryHandler(IMongoDatabase database)
        {
            _categoryCollection = database.GetCollection<Category>("Categories");
        }

        public async Task<Category> Handle(GetCategoryByIdQuery query)
        {
            // Burada query.Id artık ObjectId türünde
            var filter = Builders<Category>.Filter.Eq(a => a.CategoryID, query.Id);  // ObjectId ile filtreleme

            var about = await _categoryCollection.Find(filter).FirstOrDefaultAsync();

            if (about == null)
            {
                throw new Exception("Base kaydı bulunamadı.");
            }

            return about;
        }

    }
}