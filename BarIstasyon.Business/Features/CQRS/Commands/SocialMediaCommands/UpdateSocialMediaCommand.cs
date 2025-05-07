using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.SocialMediaCommands
{
	public class UpdateSocialMediaCommand
	{
        public string Name { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }
    }
}

