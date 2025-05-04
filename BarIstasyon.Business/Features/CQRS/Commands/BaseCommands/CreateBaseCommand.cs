using System;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Commands.BaseCommands
{
	public class CreateBaseCommand
	{
       

        public string Name { get; set; }

        public List<Coffee> Coffees { get; set; }
    }
}

