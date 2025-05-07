using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Queries
{
    public class GetSocialMediaByIdQuery
    {
        public GetSocialMediaByIdQuery(ObjectId id)
        {
            Id = id;
        }

        public ObjectId Id { get; set; }
    }
}

