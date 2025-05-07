using System;
namespace BarIstasyon.Business.Features.CQRS.Commands.SocialMediaCommands
{
	public class RemoveSocialMediaCommand
	{
        public object SocialMediaId { get; set; }
        public RemoveSocialMediaCommand(int id)
        {
            SocialMediaId = id;
        }
    }
}

