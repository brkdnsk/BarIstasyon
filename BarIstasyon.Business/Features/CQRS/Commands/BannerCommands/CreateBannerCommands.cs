using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.BannerCommands
{
	public class CreateBannerCommands
	{
       

        public string Title { get; set; }

        public string Description { get; set; }

        public string VideoDescription { get; set; }

        public string VideoUrl { get; set; }
    }
}

