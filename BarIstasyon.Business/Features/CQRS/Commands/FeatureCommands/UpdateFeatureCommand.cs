using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Business.Features.CQRS.Commands.FeatureCommands
{
	public class UpdateFeatureCommand
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId FeatureID { get; set; }
        public string Name { get; set; }
    }
}

