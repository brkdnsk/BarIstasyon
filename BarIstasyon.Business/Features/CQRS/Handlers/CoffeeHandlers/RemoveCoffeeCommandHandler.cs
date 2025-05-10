using System;

using BarIstasyon.Business.Features.CQRS.Commands.CoffeeCommands;

using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeHandlers
{
    public class RemoveCoffeeCommandHandler
    {
        private readonly IRepository<Coffee> _repository;
        public RemoveCoffeeCommandHandler(IRepository<Coffee> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCoffeeCommand command)
        {
            var coffee = await _repository.GetByIdAsync(command.id);
            if (coffee == null)
            {
                throw new Exception("Hakkımda bilgisi bulunamadı, silme işlemi yapılmadı.");
            }

            // Silme işlemi
            await _repository.RemoveAsync(command.id);

        }
    }
}

