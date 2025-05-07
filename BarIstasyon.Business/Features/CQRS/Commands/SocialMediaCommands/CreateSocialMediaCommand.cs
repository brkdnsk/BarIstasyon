using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.SocialMediaCommands
{
	public class CreateSocialMediaCommand
	{
        public string Name { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }
    }
}

