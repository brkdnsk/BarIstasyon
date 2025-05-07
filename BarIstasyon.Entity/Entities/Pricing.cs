using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Entity.Entities
{
	public class Pricing
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId PricingID { get; set; }

        public string Name { get; set; }

        public List<CoffeePricing> CoffeePricings { get; set; }
    }
}

