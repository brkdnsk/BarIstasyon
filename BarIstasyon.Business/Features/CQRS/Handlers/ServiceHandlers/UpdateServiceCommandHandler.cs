using BarIstasyon.Business.Features.CQRS.Commands.ServiceCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using BarIstasyon.Business.Features.CQRS.Handlers.ServiceHandlers;


using MongoDB.Bson;
using System;
using System.Threading.Tasks;

public class UpdateServiceCommandHandler
{
    private readonly IRepository<Service> _ServiceRepository;

    public UpdateServiceCommandHandler(IRepository<Service> ServiceRepository)
    {
        _ServiceRepository = ServiceRepository;
    }

    public async Task Handle(UpdateServiceCommand command)
    {
        var Services = await _ServiceRepository.GetByIdAsync(command.ServiceID);
        if (Services == null)
        {
            throw new Exception("Service entity bulunamadı.");
        }

        Services.Description = command.Description;
        Services.Icon = command.Icon;



        await _ServiceRepository.UpdateAsync(command.ServiceID, Services);  // Güncellenmiş about nesnesini repository'de güncelliyoruz
    }
}
