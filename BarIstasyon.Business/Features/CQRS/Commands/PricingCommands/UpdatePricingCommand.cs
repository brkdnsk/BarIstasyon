using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Business.Features.CQRS.Commands.PricingCommands
{
	public class UpdatePricingCommand
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId PricingID { get; set; }
        public string Name { get; set; }
    }
}

