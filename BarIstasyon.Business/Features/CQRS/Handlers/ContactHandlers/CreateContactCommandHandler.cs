using System;
using System.Threading.Tasks;

using BarIstasyon.Business.Features.CQRS.Commands.ContactCommands;
using BarIstasyon.DataAccess.Repositories2;
using BarIstasyon.Entity.Entities;

namespace BarIstasyon.Business.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateContactCommand command)
        {
            try
            {
                if (command == null)
                    throw new ArgumentNullException(nameof(command), "Command cannot be null");

                var contact = new Contact
                {
                    Email=command.Email,
                    Name=command.Name,
                    Subject=command.Subject,
                    Message=command.Message,
                    SendDate=command.SendDate


                };

                await _repository.CreateAsync(contact);
                return true; // Indicates success
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                // You can use a logging framework like Serilog, NLog, or log4net.
                throw new InvalidOperationException("An error occurred while creating Category entry.", ex);
            }
        }
    }
}
