using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Entity.Entities
{
	public class CoffeeFeature
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId CoffeeFeatureID { get; set; }

       

        

       

        public string Avaliable { get; set; }
    }
}

