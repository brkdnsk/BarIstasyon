using System;
using System.Threading.Tasks;

using BarIstasyon.Business.Features.CQRS.Commands.SocialMediaCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class CreateSocialMediaCommandHandler
    {
        private readonly IRepository<SocialMedia> _repository;

        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateSocialMediaCommand command)
        {
            try
            {
                if (command == null)
                    throw new ArgumentNullException(nameof(command), "Command cannot be null");

                var socialMedia = new SocialMedia
                {
                    Icon=command.Icon,
                    Name=command.Name,
                    Url=command.Url,
                };

                await _repository.CreateAsync(socialMedia);
                return true; // Indicates success
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                // You can use a logging framework like Serilog, NLog, or log4net.
                throw new InvalidOperationException("An error occurred while creating Social Media entry.", ex);
            }
        }
    }
}
