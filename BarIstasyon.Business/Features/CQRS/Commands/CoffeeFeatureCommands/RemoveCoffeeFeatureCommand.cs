using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeeFeatureCommands
{
	public class RemoveCoffeeFeatureCommand
	{
        public object CoffeeFeaturesId { get; set; }
        public RemoveCoffeeFeatureCommand(int id)
        {
            CoffeeFeaturesId = id;
        }
    }
}

