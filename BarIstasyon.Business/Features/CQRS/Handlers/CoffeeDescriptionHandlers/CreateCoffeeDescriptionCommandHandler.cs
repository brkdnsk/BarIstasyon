using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeDescriptionCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeDescriptionHandlers
{
    public class CreateCoffeeDescriptionCommandHandler
    {
        private readonly IRepository<CoffeeDescription> _repository;

        public CreateCoffeeDescriptionCommandHandler(IRepository<CoffeeDescription> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateCoffeeDescriptionCommand command)
        {
            try
            {
                if (command == null)
                    throw new ArgumentNullException(nameof(command), "Command cannot be null");

                var coffeeDescription = new CoffeeDescription
                {
                    Coffee = command.Coffee,
                    Details = command.Details,
                  
                };

                await _repository.CreateAsync(coffeeDescription);
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