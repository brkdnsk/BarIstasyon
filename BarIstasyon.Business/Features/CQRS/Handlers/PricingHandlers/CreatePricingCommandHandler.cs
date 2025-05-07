using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.PricingCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.PricingHandlers
{
    public class CreatePricingCommandHandler
    {
        private readonly IRepository<Pricing> _repository;

        public CreatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreatePricingCommand command)
        {
            try
            {
                if (command == null)
                    throw new ArgumentNullException(nameof(command), "Command cannot be null");

                var pricing = new Pricing
                {
                    Name = command.Name,

                };

                await _repository.CreateAsync(pricing);
                return true; // Indicates success
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                // You can use a logging framework like Serilog, NLog, or log4net.
                throw new InvalidOperationException("An error occurred while creating Location entry.", ex);
            }
        }
    }
}
