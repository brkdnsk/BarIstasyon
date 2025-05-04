using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.BaseCommands
{
	public class RemoveBaseCommand
	{
        public object BaseId { get; set; }
        public RemoveBaseCommand(int id)
        {
            BaseId = id;
        }
    }
}

