using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Queries
{
    public class GetFeatureByIdQuery
    {
        public GetFeatureByIdQuery(ObjectId id)
        {
            Id = id;
        }

        public ObjectId Id { get; set; }
    }
}

