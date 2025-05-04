using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Entity.Entities
{
	public class Category
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId CategoryID { get; set; }

        public string Name { get; set; }
    }
}

