using System;
using BarIstasyon.Entity.Entities;
namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeeFeatureCommands
{
	public class RemoveCoffeeFeatureCommand
	{
        public object CoffeeFeatureId { get; set; }
        public RemoveCoffeeFeatureCommand(int id)
        {
            CoffeeFeatureId = id;
        }
    }
}

