using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Queries.BannerQueries
{
    public class GetBannerByIdQuery
    {
        public GetBannerByIdQuery(ObjectId id)  
        {
            Id = id;
        }

        public ObjectId Id { get; set; }  

    }
}
