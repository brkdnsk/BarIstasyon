using System;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeePricingCommands
{
	public class CreateCoffeePricingCommand
	{
        public Coffee Coffee { get; set; }
    }
}

