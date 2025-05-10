using System;

using BarIstasyon.Business.Features.CQRS.Commands.FeatureCommands;

using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler
    {
        private readonly IRepository<Feature> _repository;
        public RemoveFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveFeatureCommand command)
        {
            var feature = await _repository.GetByIdAsync(command.id);
            if (feature == null)
            {
                throw new Exception("Hakkımda bilgisi bulunamadı, silme işlemi yapılmadı.");
            }

            // Silme işlemi
            await _repository.RemoveAsync(command.id);

        }
    }
}

