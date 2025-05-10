using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeCommands;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.CoffeeHandlers
{
    public class CreateCoffeeCommandHandler
    {
        private readonly IRepository<Coffee> _repository;

        public CreateCoffeeCommandHandler(IRepository<Coffee> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateCoffeeCommand command)
        {
            try
            {
                if (command == null)
                    throw new ArgumentNullException(nameof(command), "Command cannot be null");

                var newcoffee = new Coffee
                {
                    CoverImageURL = command.CoverImageURL,
                    WaterML = command.WaterML,
                    CoffeeML = command.CoffeeML,
                    FoamML = command.FoamML,
                    MilkML = command.MilkML,
                    SugarOrSweetener = command.SugarOrSweetener,
                    ExtraIngredients = command.ExtraIngredients,
                    BrewingTime = command.BrewingTime,
                    BrewingType = command.BrewingType,
                    BigImageURL = command.BigImageURL,

                };

                await _repository.CreateAsync(newcoffee);
                return true; // Indicates success
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                // You can use a logging framework like Serilog, NLog, or log4net.
                throw new InvalidOperationException("An error occurred while creating Base entry.", ex);
            }
        }
    }
}
