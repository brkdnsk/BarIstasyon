﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Business.Features.CQRS.Results.ContactResults
{
	public class GetContactByIdQueryResults
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ContactID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime SendDate { get; set; }
    }
}

