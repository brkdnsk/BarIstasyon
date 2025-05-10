using System;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeFeatureCommands;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeFeatureCommands;

using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeFeatureHandlers
{
    public class RemoveCoffeeFeatureCommandHandler
    {
        private readonly IRepository<CoffeeFeature> _repository;
        public RemoveCoffeeFeatureCommandHandler(IRepository<CoffeeFeature> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCoffeeFeatureCommand command)
        {
            var coffeeFeature = await _repository.GetByIdAsync(command.id);
            if (coffeeFeature == null)
            {
                throw new Exception("Hakkımda bilgisi bulunamadı, silme işlemi yapılmadı.");
            }

            // Silme işlemi
            await _repository.RemoveAsync(command.id);

        }
    }
}

