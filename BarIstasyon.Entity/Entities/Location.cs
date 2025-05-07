using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Entity.Entities
{
	public class Location
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId LocationID { get; set; }

		public string Name { get; set; }
	}
}

