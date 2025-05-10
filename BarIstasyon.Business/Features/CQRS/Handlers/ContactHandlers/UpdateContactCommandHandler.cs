using BarIstasyon.Business.Features.CQRS.Commands.BaseCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using BarIstasyon.Business.Features.CQRS.Handlers.BaseHandlers;


using MongoDB.Bson;
using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.ContactCommands;

public class UpdateContactCommandHandler
{
    private readonly IRepository<Contact> _contactRepository;

    public UpdateContactCommandHandler(IRepository<Contact> contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task Handle(UpdateContactCommand command)
    {
        var contact = await _contactRepository.GetByIdAsync(command.ContactID);
        if (contact == null)
        {
            throw new Exception("Base entity bulunamadı.");
        }

        contact.Name = command.Name;
        contact.Email = command.Email;
        contact.Subject = command.Subject;
        contact.Message = command.Message;
        contact.SendDate = command.SendDate;
        


        await _contactRepository.UpdateAsync(command.ContactID, contact);  // Güncellenmiş about nesnesini repository'de güncelliyoruz
    }
}
