using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Queries.CategoryQueries
{
    public class GetCoffeeDescriptionByIdQuery
    {
        public GetCoffeeDescriptionByIdQuery(ObjectId id)
        {
            Id = id;
        }

        public ObjectId Id { get; set; }

    }
}

