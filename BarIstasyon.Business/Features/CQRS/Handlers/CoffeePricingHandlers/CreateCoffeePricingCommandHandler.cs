using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeePricingCommands;

using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeePricingHandlers
{
    public class CreateCoffeePricingCommandHandler
    {
        private readonly IRepository<CoffeePricing> _repository;

        public CreateCoffeePricingCommandHandler(IRepository<CoffeePricing> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateCoffeePricingCommand command)
        {
            try
            {
                if (command == null)
                    throw new ArgumentNullException(nameof(command), "Command cannot be null");

                var coffeePricing = new CoffeePricing
                {
                    EquipmentPrice = command.EquipmentPrice,


                };

                await _repository.CreateAsync(coffeePricing);
                return true; // Indicates success
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                // You can use a logging framework like Serilog, NLog, or log4net.
                throw new InvalidOperationException("An error occurred while creating Category entry.", ex);
            }
        }
    }
}
