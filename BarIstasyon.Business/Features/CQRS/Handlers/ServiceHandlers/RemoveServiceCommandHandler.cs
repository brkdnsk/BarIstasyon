using System;

using BarIstasyon.Business.Features.CQRS.Commands.ServiceCommands;

using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.ServiceHandlers
{
    public class RemoveServiceCommandHandler
    {
        private readonly IRepository<Service> _repository;
        public RemoveServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveServiceCommand command)
        {
            var Services = await _repository.GetByIdAsync(command.id);
            if (Services == null)
            {
                throw new Exception("Hakkımda bilgisi bulunamadı, silme işlemi yapılmadı.");
            }

            // Silme işlemi
            await _repository.RemoveAsync(command.id);

        }
    }
}

