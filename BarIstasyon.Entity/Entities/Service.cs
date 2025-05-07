using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Entity.Entities
{
	public class Service
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ServiceID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
    }
}

