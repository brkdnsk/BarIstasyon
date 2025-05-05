using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.ContactCommands
{
	public class UpdateContactCommand
	{
        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime SendDate { get; set; }
    }
}

