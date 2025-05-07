using System;
using System.Threading.Tasks;

using BarIstasyon.Business.Features.CQRS.Commands.ServiceCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler
    {
        private readonly IRepository<Service> _repository;

        public CreateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateServiceCommand command)
        {
            try
            {
                if (command == null)
                    throw new ArgumentNullException(nameof(command), "Command cannot be null");

                var service = new Service
                {
                    Title = command.Title,
                    Description=command.Description,
                    Icon=command.Icon,

                };

                await _repository.CreateAsync(service);
                return true; // Indicates success
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                // You can use a logging framework like Serilog, NLog, or log4net.
                throw new InvalidOperationException("An error occurred while creating Service entry.", ex);
            }
        }
    }
}
