using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.AboutCommands;
using BarIstasyon.Business.Features.CQRS.Commands.FeatureCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler
    {
        private readonly IRepository<Feature> _repository;

        public CreateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateFeatureCommand command)
        {
            try
            {
                if (command == null)
                    throw new ArgumentNullException(nameof(command), "Command cannot be null");

                var feature = new Feature
                {
                    Name = command.Name,
                    
                };

                await _repository.CreateAsync(feature);
                return true; // Indicates success
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                // You can use a logging framework like Serilog, NLog, or log4net.
                throw new InvalidOperationException("An error occurred while creating About entry.", ex);
            }
        }
    }
}
