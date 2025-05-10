using BarIstasyon.Business.Features.CQRS.Commands.FooterAddressCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using BarIstasyon.Business.Features.CQRS.Handlers.FooterAddressHandlers;


using MongoDB.Bson;
using System;
using System.Threading.Tasks;

public class UpdateFooterAddressCommandHandler
{
    private readonly IRepository<FooterAddress> _footerAddressRepository;

    public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> footerAddressRepository)
    {
        _footerAddressRepository = footerAddressRepository;
    }

    public async Task Handle(UpdateFooterAddressCommand command)
    {
        var footerAddress = await _footerAddressRepository.GetByIdAsync(command.FooterAddressId);
        if (footerAddress == null)
        {
            throw new Exception("Footer Address entity bulunamadı.");
        }

        footerAddress.Description = command.Description;
        footerAddress.Adress = command.Adress;
        footerAddress.PhoneNumber = command.PhoneNumber;
        footerAddress.Email = command.Email;


        await _footerAddressRepository.UpdateAsync(command.FooterAddressId, footerAddress);  // Güncellenmiş about nesnesini repository'de güncelliyoruz
    }
}
