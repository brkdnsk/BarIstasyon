using System;

using BarIstasyon.Business.Features.CQRS.Commands.PricingCommands;

using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.PricingHandlers
{
    public class RemovePricingCommandHandler
    {
        private readonly IRepository<Pricing> _repository;
        public RemovePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemovePricingCommand command)
        {
            var Pricings = await _repository.GetByIdAsync(command.id);
            if (Pricings == null)
            {
                throw new Exception("Hakkımda bilgisi bulunamadı, silme işlemi yapılmadı.");
            }

            // Silme işlemi
            await _repository.RemoveAsync(command.id);

        }
    }
}

