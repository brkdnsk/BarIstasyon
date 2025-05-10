using BarIstasyon.Business.Features.CQRS.Commands.CoffeeFeatureCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeFeatureHandlers;


using MongoDB.Bson;
using System;
using System.Threading.Tasks;

public class UpdateCoffeeFeatureCommandHandler
{
    private readonly IRepository<CoffeeFeature> _coffeeFeatureRepository;

    public UpdateCoffeeFeatureCommandHandler(IRepository<CoffeeFeature> coffeeFeatureRepository)
    {
        _coffeeFeatureRepository = coffeeFeatureRepository;
    }

    public async Task Handle(UpdateCoffeeFeatureCommand command)
    {
        var coffeeFeature = await _coffeeFeatureRepository.GetByIdAsync(command.CoffeeFeatureID);
        if (coffeeFeature == null)
        {
            throw new Exception("Coffee Feature entity bulunamadı.");
        }

        coffeeFeature.Avaliable = command.Avaliable;


        await _coffeeFeatureRepository.UpdateAsync(command.CoffeeFeatureID, coffeeFeature);  // Güncellenmiş about nesnesini repository'de güncelliyoruz
    }
}
