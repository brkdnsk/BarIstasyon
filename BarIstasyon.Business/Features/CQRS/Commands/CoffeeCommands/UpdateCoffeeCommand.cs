using System;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeeCommands
{
	public class UpdateCoffeeCommand
	{

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId CoffeeId { get; set; }

        public string CoverImageURL { get; set; }

        public int WaterML { get; set; }

        public int CoffeeML { get; set; }

        public int MilkML { get; set; }

        public int FoamML { get; set; }

        public string SugarOrSweetener { get; set; }

        public string ExtraIngredients { get; set; }

        public int BrewingTime { get; set; }

        public string BrewingType { get; set; }

        public string BigImageURL { get; set; }

        
    }
}

