using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeePricingCommands
{
	public class RemoveCoffeePricingCommand
	{
        public object CoffeePricingId { get; set; }
        public RemoveCoffeePricingCommand(int id)
        {
            CoffeePricingId = id;
        }
    }
}

