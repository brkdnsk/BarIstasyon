using System;

using BarIstasyon.Business.Features.CQRS.Commands.LocationCommands;

using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.LocationHandlers
{
    public class RemoveLocationCommandHandler
    {
        private readonly IRepository<Location> _repository;
        public RemoveLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveLocationCommand command)
        {
            var Locations = await _repository.GetByIdAsync(command.id);
            if (Locations == null)
            {
                throw new Exception("Hakkımda bilgisi bulunamadı, silme işlemi yapılmadı.");
            }

            // Silme işlemi
            await _repository.RemoveAsync(command.id);

        }
    }
}

