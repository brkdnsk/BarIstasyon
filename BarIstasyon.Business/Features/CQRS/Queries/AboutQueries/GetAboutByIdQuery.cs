using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {
        public GetAboutByIdQuery(ObjectId id)  // ObjectId olarak değiştiriyoruz
        {
            Id = id;
        }

        public ObjectId Id { get; set; }  // Id de ObjectId türünde
        
    }
}
