using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeeDescriptionCommands
{
	public class RemoveCoffeeDescriptionCommand
	{
        public object CoffeeDescriptionId { get; set; }
        public RemoveCoffeeDescriptionCommand(int id)
        {
            CoffeeDescriptionId = id;
        }
    }
}

