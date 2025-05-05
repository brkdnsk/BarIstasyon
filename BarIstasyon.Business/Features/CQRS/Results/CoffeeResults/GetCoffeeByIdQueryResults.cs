using System;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;

namespace BarIstasyon.Business.Features.CQRS.Results.CoffeeResults
{
	public class GetCoffeeByIdQueryResults
	{
        public ObjectId CoffeeId { get; set; }
        public string BasesID { get; set; }

        public Base Base { get; set; }

        public string CoverImageURL { get; set; }

        public int WaterML { get; set; }

        public int CoffeeML { get; set; }

        public int MilkML { get; set; }

        public int FoamML { get; set; }

        public bool SugarOrSweetener { get; set; }

        public bool ExtraIngredients { get; set; }

        public int BrewingTime { get; set; }

        public string BrewingType { get; set; }

        public string BigImageURL { get; set; }

       
    }
}

