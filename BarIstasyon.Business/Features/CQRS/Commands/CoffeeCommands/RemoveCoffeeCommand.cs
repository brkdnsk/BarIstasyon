using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeeCommands
{
	public class RemoveCoffeeCommand
	{
        public object CoffeeId { get; set; }
        public RemoveCoffeeCommand(int id)
        {
            CoffeeId = id;
        }
    }
}

