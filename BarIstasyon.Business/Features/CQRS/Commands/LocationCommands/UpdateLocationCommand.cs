using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Business.Features.CQRS.Commands.LocationCommands
{
	public class UpdateLocationCommand
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId LocationID { get; set; }
        public string Name { get; set; }
    }
}

