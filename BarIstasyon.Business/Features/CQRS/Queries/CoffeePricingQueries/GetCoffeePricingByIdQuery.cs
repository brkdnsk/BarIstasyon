using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Queries.CoffeePricingQueries
{
    public class GetCoffeePricingByIdQuery
    {
        public GetCoffeePricingByIdQuery(ObjectId id)
        {
            Id = id;
        }

        public ObjectId Id { get; set; }
    }
}

