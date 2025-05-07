using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.FooterAddressCommands
{
	public class RemoveFooterAddressCommand
	{
        public object FooterAddressId { get; set; }
        public RemoveFooterAddressCommand(int id)
        {
            FooterAddressId = id;
        }
    }
}

