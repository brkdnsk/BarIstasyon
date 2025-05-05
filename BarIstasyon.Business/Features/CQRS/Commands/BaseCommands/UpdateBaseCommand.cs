using System;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Commands.BaseCommands
{
	public class UpdateBaseCommand
	{
        public string BaseID { get; set; }

        public string Name { get; set; }

        
    }
}

