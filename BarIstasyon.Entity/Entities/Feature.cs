using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Entity.Entities
{
	public class Feature
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId FeatureID { get; set; }

        public string Name { get; set; }

        
    }
}

