using System;
using BarIstasyon.Business.Features.CQRS.Commands.BaseCommands;
using BarIstasyon.Business.Features.CQRS.Commands.FooterAddressCommands;

using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class RemoveFooterAddressCommandHandler
    {
        private readonly IRepository<FooterAddress> _repository;
        public RemoveFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveFooterAddressCommand command)
        {
            var footerAddress = await _repository.GetByIdAsync(command.id);
            if (footerAddress == null)
            {
                throw new Exception("Hakkımda bilgisi bulunamadı, silme işlemi yapılmadı.");
            }

            // Silme işlemi
            await _repository.RemoveAsync(command.id);

        }
    }
}

