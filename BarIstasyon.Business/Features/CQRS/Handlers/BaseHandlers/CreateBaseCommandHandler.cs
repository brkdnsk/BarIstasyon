using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.AboutCommands;
using BarIstasyon.Business.Features.CQRS.Commands.BaseCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.BaseHandlers
{
    public class CreateBaseCommandHandler
    {
        private readonly IRepository<Base> _repository;

        public CreateBaseCommandHandler(IRepository<Base> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateBaseCommand command)
        {
            try
            {
                if (command == null)
                    throw new ArgumentNullException(nameof(command), "Command cannot be null");

                var newbase=new Base
                {
                    Name = command.Name,
                    Coffees = command.Coffees,
                    
                };

                await _repository.CreateAsync(newbase);
                return true; // Indicates success
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                // You can use a logging framework like Serilog, NLog, or log4net.
                throw new InvalidOperationException("An error occurred while creating Base entry.", ex);
            }
        }
    }
}
