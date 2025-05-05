using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Queries.CoffeeFeaturesQueries
{
	public class GetCoffeeFeatureByIdQuery
	{
        public GetCoffeeFeatureByIdQuery(ObjectId id)
        {
            Id = id;
        }

        public ObjectId Id { get; set; }
    }
}

