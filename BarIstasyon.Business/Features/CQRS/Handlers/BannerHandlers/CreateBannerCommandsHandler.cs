using System;
using BarIstasyon.Business.Features.CQRS.Commands.AboutCommands;
using BarIstasyon.Business.Features.CQRS.Commands.BannerCommands;
using BarIstasyon.Business.Interfaces;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.BannerHandlers
{
	public class CreateBannerCommandsHandler
	{
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandsHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateBannerCommands command)
        {
            try
            {
                if (command == null)
                    throw new ArgumentNullException(nameof(command), "Command cannot be null");

                var Banner = new Banner
                {
                    Title = command.Title,
                    Description = command.Description,
                    VideoUrl = command.VideoUrl
                };

                await _repository.CreateAsync(Banner);
                return true; // Indicates success
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                // You can use a logging framework like Serilog, NLog, or log4net.
                throw new InvalidOperationException("An error occurred while creating Banner entry.", ex);
            }
        }
    }
}

