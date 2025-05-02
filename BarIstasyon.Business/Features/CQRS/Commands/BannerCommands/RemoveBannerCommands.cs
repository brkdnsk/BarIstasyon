using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.BannerCommands
{
	public class RemoveBannerCommands
	{
        public object BannerId { get; set; }
        public RemoveBannerCommands(int id)
        {
            BannerId = id;
        }
    }
}

