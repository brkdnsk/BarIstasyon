using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.FooterAddressCommands
{
	public class CreateFooterAddressCommand
	{
        public string Description { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}

