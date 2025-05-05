using System;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Commands.CoffeeFeatureCommands
{
	public class UpdateCoffeeFeatureCommand
	{
        public Coffee Coffee { get; set; }

        public Feature Feature { get; set; }

        public bool Avaliable { get; set; }
    }
}

