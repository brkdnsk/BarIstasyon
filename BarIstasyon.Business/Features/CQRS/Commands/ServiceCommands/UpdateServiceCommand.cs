using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.ServiceCommands
{
	public class UpdateServiceCommand
	{
        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
    }
}

