using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Queries.BannerQueries
{
    public class GetBannerByIdQuery
    {
        public ObjectId Id { get; set; }

        public GetBannerByIdQuery(ObjectId id)
        {
            Id = id;
        }
    }
}
