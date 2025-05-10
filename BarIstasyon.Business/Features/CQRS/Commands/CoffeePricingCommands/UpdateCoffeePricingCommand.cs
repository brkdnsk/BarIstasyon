using System;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeePricingCommands
{
	public class UpdateCoffeePricingCommand
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId PricingID { get; set; }
        public int EquipmentPrice { get; set; }
    }
}

