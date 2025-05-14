using System.Collections.Generic;
using System.Threading.Tasks;
using BarIstasyon.Entity.Entities;
using MongoDB.Driver;
using BarIstasyon.Business.Features.CQRS.Queries.AboutQueries;
using BarIstasyon.Dto.AboutDtos;

// DTO model

namespace BarIstasyon.Business.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAllAboutQueryHandler
    {
        private readonly IMongoCollection<About> _aboutCollection;

        public GetAllAboutQueryHandler(IMongoDatabase database)
        {
            _aboutCollection = database.GetCollection<About>("Abouts");
        }

        public async Task<List<ResultAboutDto>> Handle(GetAllAboutQuery query)
        {
            // MongoDB'den tüm 'About' verilerini al
            var aboutList = await _aboutCollection.Find(_ => true).ToListAsync();

            // List<About> verilerini DTO'ya dönüştür
            var result = new List<ResultAboutDto>();

            foreach (var about in aboutList)
            {
                result.Add(new ResultAboutDto
                {
                    AboutID = about.AboutID.ToString(),  // ObjectId'yi string'e dönüştür
                    title = about.Title,
                    description=about.Description,
                    imageURL=about.ImageURL
                    
                });
            }

            return result;
        }
    }
}
