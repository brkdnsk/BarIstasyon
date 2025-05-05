using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.ContactCommands
{
	public class RemoveContactCommand
	{
        public object ContactId { get; set; }
        public RemoveContactCommand(int id)
        {
            ContactId = id;
        }
    }
}

