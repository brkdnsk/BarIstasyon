using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Entity.Entities
{
	public class SocialMedia
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId SocialMediaID { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }
    }
}

