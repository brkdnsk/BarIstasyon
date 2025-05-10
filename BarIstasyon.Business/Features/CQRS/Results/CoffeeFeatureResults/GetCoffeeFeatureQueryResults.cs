using System;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Results.CoffeeFeatureResults
{
	public class GetCoffeeFeatureQueryResults
	{
        public ObjectId CoffeeFeatureID { get; set; }



        

      

        public bool Avaliable { get; set; }
    }
}

