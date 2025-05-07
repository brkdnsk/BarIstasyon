using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.PricingCommands
{
	public class RemovePricingCommand
	{
        public object PricingId { get; set; }
        public RemovePricingCommand(int id)
        {
            PricingId = id;
        }
    }
}

