using BarIstasyon.Business.Features.CQRS.Commands.BaseCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using BarIstasyon.Business.Features.CQRS.Handlers.BaseHandlers;


using MongoDB.Bson;
using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeDescriptionCommands;

public class UpdateCoffeeDescriptionCommandHandler
{
    private readonly IRepository<CoffeeDescription> _coffeeDescriptionRepository;

    public UpdateCoffeeDescriptionCommandHandler(IRepository<CoffeeDescription> coffeeDescriptionRepository)
    {
        _coffeeDescriptionRepository = coffeeDescriptionRepository;
    }

    public async Task Handle(UpdateCoffeeDescriptionCommand command)
    {
        var coffeedescription = await _coffeeDescriptionRepository.GetByIdAsync(command.CoffeeDescriptionID);
        if (coffeedescription == null)
        {
            throw new Exception("Coffee Description entity bulunamadı.");
        }

        coffeedescription.Details = command.Details;


        await _coffeeDescriptionRepository.UpdateAsync(command.CoffeeDescriptionID, coffeedescription);  // Güncellenmiş about nesnesini repository'de güncelliyoruz
    }
}
