using System;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Business.Features.CQRS.Commands.BaseCommands
{
	public class UpdateBaseCommand
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId id { get; set; }

        public string Name { get; set; }

        
    }
}

