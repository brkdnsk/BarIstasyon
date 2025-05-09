using System;

using BarIstasyon.Business.Features.CQRS.Commands.BaseCommands;

using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.BaseHandlers
{
    public class RemoveBaseCommandHandler
    {
        private readonly IRepository<Base> _repository;
        public RemoveBaseCommandHandler(IRepository<Base> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveBaseCommand command)
        {
            var bases = await _repository.GetByIdAsync(command.id);
            if (bases == null)
            {
                throw new Exception("Hakkımda bilgisi bulunamadı, silme işlemi yapılmadı.");
            }

            // Silme işlemi
            await _repository.RemoveAsync(command.id);

        }
    }
}

