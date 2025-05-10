using System;

using BarIstasyon.Business.Features.CQRS.Commands.SocialMediaCommands;

using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class RemoveSocialMediaCommandHandler
    {
        private readonly IRepository<SocialMedia> _repository;
        public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveSocialMediaCommand command)
        {
            var SocialMedias = await _repository.GetByIdAsync(command.id);
            if (SocialMedias == null)
            {
                throw new Exception("Hakkımda bilgisi bulunamadı, silme işlemi yapılmadı.");
            }

            // Silme işlemi
            await _repository.RemoveAsync(command.id);

        }
    }
}

