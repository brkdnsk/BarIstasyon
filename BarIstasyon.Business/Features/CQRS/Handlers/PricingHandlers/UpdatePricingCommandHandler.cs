using BarIstasyon.Business.Features.CQRS.Commands.PricingCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using BarIstasyon.Business.Features.CQRS.Handlers.PricingHandlers;


using MongoDB.Bson;
using System;
using System.Threading.Tasks;

public class UpdatePricingCommandHandler
{
    private readonly IRepository<Pricing> _PricingRepository;

    public UpdatePricingCommandHandler(IRepository<Pricing> PricingRepository)
    {
        _PricingRepository = PricingRepository;
    }

    public async Task Handle(UpdatePricingCommand command)
    {
        var Pricings = await _PricingRepository.GetByIdAsync(command.PricingID);
        if (Pricings == null)
        {
            throw new Exception("Pricing entity bulunamadı.");
        }

        Pricings.Name = command.Name;


        await _PricingRepository.UpdateAsync(command.PricingID, Pricings);  // Güncellenmiş about nesnesini repository'de güncelliyoruz
    }
}
