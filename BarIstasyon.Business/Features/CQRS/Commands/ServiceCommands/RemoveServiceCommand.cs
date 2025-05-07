using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.ServiceCommands
{
	public class RemoveServiceCommand
	{
        public object ServiceId { get; set; }
        public RemoveServiceCommand(int id)
        {
            ServiceId = id;
        }
    }
}

