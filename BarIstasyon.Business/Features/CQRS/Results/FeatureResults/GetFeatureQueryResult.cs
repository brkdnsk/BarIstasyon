using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Results.FeatureResults
{
	public class GetFeatureQueryResult
	{
        public ObjectId FeatureID { get; set; }

        public string Name { get; set; }
    }
}

