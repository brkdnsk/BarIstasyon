using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Results.ServiceResults
{
	public class GetServiceQueryResult
	{
        public ObjectId ServiceID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
    }
}

