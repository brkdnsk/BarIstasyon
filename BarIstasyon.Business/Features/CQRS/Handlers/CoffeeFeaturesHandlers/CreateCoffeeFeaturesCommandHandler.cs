using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeDescriptionCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeFeaturesHandlers
{
    public class CreateCoffeeFeaturesCommandHandler
    {
        private readonly IRepository<CoffeeFeature> _repository;

        public CreateCoffeeFeaturesCommandHandler(IRepository<CoffeeFeature> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateCoffeeFeaturesCommandHandler command)
        {
            try
            {
                if (command == null)
                    throw new ArgumentNullException(nameof(command), "Command cannot be null");

                var coffeeFeature = new CoffeeFeature
                {
                    

                    

                };

                await _repository.CreateAsync(coffeeFeature);
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