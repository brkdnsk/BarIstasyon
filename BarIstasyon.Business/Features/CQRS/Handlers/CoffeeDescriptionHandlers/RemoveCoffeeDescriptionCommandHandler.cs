using System;

using BarIstasyon.Business.Features.CQRS.Commands.CoffeeDescriptionCommands;

using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeDescriptionHandlers
{
    public class RemoveCoffeeDescriptionCommandHandler
    {
        private readonly IRepository<CoffeeDescription> _repository;
        public RemoveCoffeeDescriptionCommandHandler(IRepository<CoffeeDescription> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCoffeeDescriptionCommand command)
        {
            var coffeedescription = await _repository.GetByIdAsync(command.id);
            if (coffeedescription == null)
            {
                throw new Exception("Hakkımda bilgisi bulunamadı, silme işlemi yapılmadı.");
            }

            // Silme işlemi
            await _repository.RemoveAsync(command.id);

        }
    }
}

