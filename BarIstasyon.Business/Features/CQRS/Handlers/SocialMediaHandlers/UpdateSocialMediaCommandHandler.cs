using BarIstasyon.Business.Features.CQRS.Commands.SocialMediaCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using BarIstasyon.Business.Features.CQRS.Handlers.SocialMediaHandlers;


using MongoDB.Bson;
using System;
using System.Threading.Tasks;

public class UpdateSocialMediaCommandHandler
{
    private readonly IRepository<SocialMedia> _SocialMediaRepository;

    public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> SocialMediaRepository)
    {
        _SocialMediaRepository = SocialMediaRepository;
    }

    public async Task Handle(UpdateSocialMediaCommand command)
    {
        var SocialMedias = await _SocialMediaRepository.GetByIdAsync(command.SocialMediaID);
        if (SocialMedias == null)
        {
            throw new Exception("SocialMedia entity bulunamadı.");
        }

        SocialMedias.Name = command.Name;


        await _SocialMediaRepository.UpdateAsync(command.SocialMediaID, SocialMedias);  // Güncellenmiş about nesnesini repository'de güncelliyoruz
    }
}
