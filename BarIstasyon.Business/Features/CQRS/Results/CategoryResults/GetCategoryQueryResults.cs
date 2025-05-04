using System;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Results.CategoryResults
{
	public class GetCategoryQueryResults
	{
        public ObjectId CategoryID { get; set; }

        public string Name { get; set; }
    }
}

