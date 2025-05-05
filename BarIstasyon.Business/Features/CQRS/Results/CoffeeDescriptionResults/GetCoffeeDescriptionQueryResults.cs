using System;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Results.CoffeeDescriptionResults
{
	public class GetCoffeeDescriptionQueryResults
	{
        public ObjectId CoffeeDescriptionID { get; set; }



        public Coffee Coffee { get; set; }

        public int Details { get; set; }
    }
}

