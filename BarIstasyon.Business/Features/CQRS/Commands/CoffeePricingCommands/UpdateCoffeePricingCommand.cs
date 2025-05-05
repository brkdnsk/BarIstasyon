using System;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeePricingCommands
{
	public class UpdateCoffeePricingCommand
	{
        public Coffee Coffee { get; set; }
    }
}

