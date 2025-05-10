using System;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeeDescriptionCommands
{
	public class CreateCoffeeDescriptionCommand
	{

        

        public int Details { get; set; }
    }
}

