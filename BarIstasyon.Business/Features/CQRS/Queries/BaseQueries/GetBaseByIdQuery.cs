using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Queries.BaseQueries
{
    public class GetBaseByIdQuery
    {
        public GetBaseByIdQuery(ObjectId id)
        {
            Id = id;
        }

        public ObjectId Id { get; set; }

    }
}
