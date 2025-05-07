using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Results.PricingResults
{
	public class GetPricingQueryResult
	{
        public ObjectId PricingID { get; set; }

        public string Name { get; set; }
    }
}

