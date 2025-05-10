using BarIstasyon.Business.Features.CQRS.Commands.LocationCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using BarIstasyon.Business.Features.CQRS.Handlers.LocationHandlers;


using MongoDB.Bson;
using System;
using System.Threading.Tasks;

public class UpdateLocationCommandHandler
{
    private readonly IRepository<Location> _LocationRepository;

    public UpdateLocationCommandHandler(IRepository<Location> LocationRepository)
    {
        _LocationRepository = LocationRepository;
    }

    public async Task Handle(UpdateLocationCommand command)
    {
        var Locations = await _LocationRepository.GetByIdAsync(command.LocationID);
        if (Locations == null)
        {
            throw new Exception("Location entity bulunamadı.");
        }

        Locations.Name = command.Name;


        await _LocationRepository.UpdateAsync(command.LocationID, Locations);  // Güncellenmiş about nesnesini repository'de güncelliyoruz
    }
}
