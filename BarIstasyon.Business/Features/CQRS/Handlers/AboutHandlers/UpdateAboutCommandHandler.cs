using BarIstasyon.Business.Features.CQRS.Commands.AboutCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

public class UpdateAboutCommandHandler
{
    private readonly IRepository<About> _aboutRepository;

    public UpdateAboutCommandHandler(IRepository<About> aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }

    public async Task Handle(UpdateAboutCommand command)
    {
        var about = await _aboutRepository.GetByIdAsync(command.id);
        if (about == null)
        {
            throw new Exception("About entity bulunamadı.");
        }

        about.Title = command.Title;
        about.Description = command.Description;
        about.ImageURL = command.ImageUrl;

        await _aboutRepository.UpdateAsync(command.id, about);  // Güncellenmiş about nesnesini repository'de güncelliyoruz
    }
}
