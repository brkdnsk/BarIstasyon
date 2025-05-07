using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Queries
{
    public class GetLocationByIdQuery
    {
        public GetLocationByIdQuery(ObjectId id)
        {
            Id = id;
        }

        public ObjectId Id { get; set; }
    }
}

