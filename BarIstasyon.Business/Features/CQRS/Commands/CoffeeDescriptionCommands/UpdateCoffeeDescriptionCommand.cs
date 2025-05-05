using System;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeeDescriptionCommands
{
	public class UpdateCoffeeDescriptionCommand
	{
        public Coffee Coffee { get; set; }

        public int Details { get; set; }
    }
}

