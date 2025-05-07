using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.FooterAddressCommands;
using BarIstasyon.Business.Features.CQRS.Commands.FooterAddressCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandler
    {
        private readonly IRepository<FooterAddress> _repository;

        public CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateFooterAddressCommand command)
        {
            try
            {
                if (command == null)
                    throw new ArgumentNullException(nameof(command), "Command cannot be null");

                var footerAddress = new FooterAddress
                {
                  Adress=command.Adress,
                  Description=command.Description,
                  PhoneNumber=command.PhoneNumber,
                  Email=command.Email,

                };

                await _repository.CreateAsync(footerAddress);
                return true; // Indicates success
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                // You can use a logging framework like Serilog, NLog, or log4net.
                throw new InvalidOperationException("An error occurred while creating About entry.", ex);
            }
        }
    }
}
