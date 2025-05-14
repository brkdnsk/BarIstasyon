using BarIstasyon.Business.Features.CQRS.Commands.AboutCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using MongoDB.Bson;

public class UpdateAboutCommandHandler
{
    private readonly IRepository<About> _aboutRepository;

    public UpdateAboutCommandHandler(IRepository<About> aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }

    public async Task Handle(UpdateAboutCommand command)
    {
        // API'den gelen id'yi ObjectId'ye dönüştür
        if (!ObjectId.TryParse(command.AboutID, out ObjectId objectId))
        {
            throw new Exception("Geçersiz id formatı.");
        }

        var about = await _aboutRepository.GetByIdAsync(objectId);  // ObjectId kullanarak veritabanında sorgulama yapıyoruz
        if (about == null)
        {
            throw new Exception("About entity bulunamadı.");
        }

        about.Title = command.Title;
        about.Description = command.Description;
        about.ImageURL = command.ImageUrl;

        await _aboutRepository.UpdateAsync(objectId, about);  // Güncellenmiş about nesnesini repository'de güncelliyoruz
    }
}
