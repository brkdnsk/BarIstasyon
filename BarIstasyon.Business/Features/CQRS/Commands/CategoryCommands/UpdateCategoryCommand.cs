using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Business.Features.CQRS.Commands.CategoryCommands
{
	public class UpdateCategoryCommand
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId CategoryID { get; set; }

        public string Name { get; set; }
    }
}

