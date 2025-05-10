using BarIstasyon.Business.Features.CQRS.Commands.CoffeeCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeHandlers;


using MongoDB.Bson;
using System;
using System.Threading.Tasks;

public class UpdateCoffeeCommandHandler
{
    private readonly IRepository<Coffee> _coffeeRepository;

    public UpdateCoffeeCommandHandler(IRepository<Coffee> coffeeRepository)
    {
        _coffeeRepository = coffeeRepository;
    }

    public async Task Handle(UpdateCoffeeCommand command)
    {
        var coffee = await _coffeeRepository.GetByIdAsync(command.CoffeeId);
        if (coffee == null)
        {
            throw new Exception("Coffee entity bulunamadı.");
        }

        coffee.CoverImageURL = command.CoverImageURL;
        coffee.WaterML = command.WaterML;
        coffee.CoffeeML = command.CoffeeML;
        coffee.MilkML = command.MilkML;
        coffee.FoamML = command.FoamML;
        coffee.SugarOrSweetener = command.SugarOrSweetener;
        coffee.ExtraIngredients = command.ExtraIngredients;
        coffee.BrewingTime = command.BrewingTime;
        coffee.BrewingType = command.BrewingType;
        coffee.BigImageURL = command.BigImageURL;
        


        await _coffeeRepository.UpdateAsync(command.CoffeeId, coffee);  // Güncellenmiş about nesnesini repository'de güncelliyoruz
    }
}
