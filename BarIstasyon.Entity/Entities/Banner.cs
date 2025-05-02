using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Entity.Entities
{
	public class Banner
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId BannerID { get; set; }
    

        public string Title { get; set; }

        public string Description { get; set; }

        public string VideoDescription { get; set; }

        public string VideoUrl { get; set; }
    }
}

