using System;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Results.BaseResults
{
	public class GetBaseByIdQueryResults
	{
        public ObjectId BaseID { get; set; }

        public string Name { get; set; }

        
    }
}

