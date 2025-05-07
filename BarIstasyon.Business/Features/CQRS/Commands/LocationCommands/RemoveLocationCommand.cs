using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.LocationCommands
{
	public class RemoveLocationCommand
	{
        public object LocationId { get; set; }
        public RemoveLocationCommand(int id)
        {
            LocationId = id;
        }
    }
}

