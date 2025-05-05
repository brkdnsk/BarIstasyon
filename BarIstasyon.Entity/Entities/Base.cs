using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Entity.Entities
{
	public class Base
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId BaseID { get; set; }

        public string Name { get; set; }

    }
}

