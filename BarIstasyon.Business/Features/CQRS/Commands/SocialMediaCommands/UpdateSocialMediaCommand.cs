using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Business.Features.CQRS.Commands.SocialMediaCommands
{
	public class UpdateSocialMediaCommand
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId SocialMediaID { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }
    }
}

