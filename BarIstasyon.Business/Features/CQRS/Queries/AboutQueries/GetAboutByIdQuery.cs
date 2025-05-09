using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {
        public ObjectId Id { get; set; }

        public GetAboutByIdQuery(ObjectId id)
        {
            Id = id;
        }
    }
}
