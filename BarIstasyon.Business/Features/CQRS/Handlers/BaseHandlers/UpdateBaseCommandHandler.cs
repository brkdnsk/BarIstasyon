using BarIstasyon.Business.Features.CQRS.Commands.BaseCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using BarIstasyon.Business.Features.CQRS.Handlers.BaseHandlers;


using MongoDB.Bson;
using System;
using System.Threading.Tasks;

public class UpdateBaseCommandHandler
{
    private readonly IRepository<Base> _baseRepository;

    public UpdateBaseCommandHandler(IRepository<Base> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public async Task Handle(UpdateBaseCommand command)
    {
        var bases = await _baseRepository.GetByIdAsync(command.id);
        if (bases == null)
        {
            throw new Exception("Base entity bulunamadı.");
        }
        
        bases.Name = command.Name;
       

        await _baseRepository.UpdateAsync(command.id, bases);  // Güncellenmiş about nesnesini repository'de güncelliyoruz
    }
}
