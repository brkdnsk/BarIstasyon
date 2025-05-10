using System;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeeFeatureCommands
{
	public class UpdateCoffeeFeatureCommand
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId CoffeeFeatureID { get; set; }

        public string Avaliable { get; set; }
    }
}

