using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Entity.Entities
{
	public class FooterAddress
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId FooterAddressId { get; set; }

        public string Description { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}

