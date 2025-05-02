using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Entity.Entities
{
	public class About
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId AboutID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }
    }
}

