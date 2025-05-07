using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Results.SocialMediaResults
{
	public class GetSocialMediaByIdQueryResult
	{
        public ObjectId SocialMediaID { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }
    }
}

