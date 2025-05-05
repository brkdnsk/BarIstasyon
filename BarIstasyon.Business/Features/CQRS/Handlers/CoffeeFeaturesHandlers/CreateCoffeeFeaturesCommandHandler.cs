using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeFeatureCommands;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeFeaturesHandlers;

using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeDescriptionHandlers
{
    public class CreateCoffeeFeatureCommandHandler
    {
        private readonly IRepository<CoffeeFeature> _repository;

        public CreateCoffeeFeatureCommandHandler(IRepository<CoffeeFeature> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateCoffeeFeatureCommand command)
        {
            try
            {
                if (command == null)
                    throw new ArgumentNullException(nameof(command), "Command cannot be null");

                var coffeeFeatures = new CoffeeFeature
                {
                   

                };

                await _repository.CreateAsync(coffeeFeatures);
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