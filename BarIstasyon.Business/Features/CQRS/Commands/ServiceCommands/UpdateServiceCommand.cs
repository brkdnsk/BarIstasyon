using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Business.Features.CQRS.Commands.ServiceCommands
{
	public class UpdateServiceCommand
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ServiceID { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
    }
}

