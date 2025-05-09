using BarIstasyon.Business.Features.CQRS.Commands.BannerCommands;

using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

public class UpdateBannerCommandHandler
{
    private readonly IRepository<Banner> _bannerRepository;

    public UpdateBannerCommandHandler(IRepository<Banner> bannerRepository)
    {
        _bannerRepository = bannerRepository;
    }

    public async Task Handle(UpdateBannerCommands command)
    {
        var banner = await _bannerRepository.GetByIdAsync(command.id);
        if (banner == null)
        {
            throw new Exception("Banner entity bulunamadı.");
        }
        
        banner.Title = command.Title;
        banner.Description = command.Description;
        banner.VideoUrl = command.VideoUrl;
        banner.VideoDescription = command.VideoDescription;
        



        await _bannerRepository.UpdateAsync(command.id, banner);  // Güncellenmiş about nesnesini repository'de güncelliyoruz
    }
}
