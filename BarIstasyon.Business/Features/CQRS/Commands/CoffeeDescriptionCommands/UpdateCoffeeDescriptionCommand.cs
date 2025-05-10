using System;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeeDescriptionCommands
{
	public class UpdateCoffeeDescriptionCommand
	{

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId CoffeeDescriptionID { get; set; }
        public Coffee Coffee { get; set; }

        public int Details { get; set; }
    }
}

