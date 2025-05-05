using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Entity.Entities
{
	public class CoffeePricing
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId CoffeePricingID { get; set; }

       

        public Coffee Coffee { get; set; }
    }
}

