using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Queries
{
    public class GetPricingByIdQuery
    {
        public GetPricingByIdQuery(ObjectId id)
        {
            Id = id;
        }

        public ObjectId Id { get; set; }
    }
}

