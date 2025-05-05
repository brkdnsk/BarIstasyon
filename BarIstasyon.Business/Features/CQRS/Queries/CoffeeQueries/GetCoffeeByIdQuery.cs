using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Queries.CoffeeQueries
{
	public class GetCoffeeByIdQuery
	{
        public GetCoffeeByIdQuery(ObjectId id)
        {
            Id = id;
        }

        public ObjectId Id { get; set; }
    }
}

