using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Entity.Entities
{
	public class CoffeeDescription
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId CoffeeDescriptionID { get; set; }

        

        public Coffee Coffee { get; set; }

        public int Details { get; set; }
    }
}

