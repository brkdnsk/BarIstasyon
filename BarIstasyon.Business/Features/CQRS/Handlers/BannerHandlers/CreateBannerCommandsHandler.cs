using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.BannerCommands;
using BarIstasyon.DataAccess.Repositories2;

using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandsHandler
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandsHandler(IRepository<Banner> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(CreateBannerCommands command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), "Command cannot be null");

            var banner = new Banner
            {
                Title = command.Title,
                Description = command.Description,
                VideoUrl = command.VideoUrl
            };

            try
            {
                await _repository.CreateAsync(banner);
                return true;
            }
            catch (Exception ex)
            {
                // Buraya isteğe bağlı olarak bir logger entegre edebilirsin
                throw new InvalidOperationException("An error occurred while creating a Banner entry.", ex);
            }
        }
    }
}
