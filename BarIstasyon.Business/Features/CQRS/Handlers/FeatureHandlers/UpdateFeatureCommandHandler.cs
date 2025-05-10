using BarIstasyon.Business.Features.CQRS.Commands.FeatureCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;
using BarIstasyon.Business.Features.CQRS.Handlers.FeatureHandlers;


using MongoDB.Bson;
using System;
using System.Threading.Tasks;

public class UpdateFeatureCommandHandler
{
    private readonly IRepository<Feature> _featureRepository;

    public UpdateFeatureCommandHandler(IRepository<Feature> featureRepository)
    {
        _featureRepository = featureRepository;
    }

    public async Task Handle(UpdateFeatureCommand command)
    {
        var feature = await _featureRepository.GetByIdAsync(command.FeatureID);
        if (feature == null)
        {
            throw new Exception("Base entity bulunamadı.");
        }

        feature.Name = command.Name;


        await _featureRepository.UpdateAsync(command.FeatureID, feature);  // Güncellenmiş about nesnesini repository'de güncelliyoruz
    }
}
