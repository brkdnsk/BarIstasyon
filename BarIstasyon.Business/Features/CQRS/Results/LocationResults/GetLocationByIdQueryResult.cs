using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Results.LocationResults
{
	public class GetLocationByIdQueryResult
	{
        public ObjectId LocationID { get; set; }

        public string Name { get; set; }
    }
}

