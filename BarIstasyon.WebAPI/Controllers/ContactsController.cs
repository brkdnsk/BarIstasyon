using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.ContactCommands;
using BarIstasyon.Business.Features.CQRS.Queries.ContactQueries;
using BarIstasyon.Business.Features.CQRS.Handlers.ContactHandlers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly GetAllContactQueryHandler _getAllContactQueryHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;

        public ContactsController(
            CreateContactCommandHandler createContactCommandHandler,
            GetAllContactQueryHandler getAllContactQueryHandler,
            UpdateContactCommandHandler updateContactCommandHandler,
            RemoveContactCommandHandler removeContactCommandHandler,
            GetContactByIdQueryHandler getContactByIdQueryHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _getAllContactQueryHandler = getAllContactQueryHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(string id, [FromBody] UpdateContactCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                command.ContactID = objectId;
                await _updateContactCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                await _createContactCommandHandler.Handle(command);
                return Ok("Hakkımda bilgisi eklendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            try
            {
                var result = await _getAllContactQueryHandler.Handle(new GetAllContactQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        // ✅ Silme endpoint'i
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                var command = new RemoveContactCommand(objectId);
                await _removeContactCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Geçersiz ID formatı.");
            }

            var result = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(objectId));
            if (result == null)
            {
                return NotFound("Kayıt bulunamadı.");
            }

            return Ok(result);
        }
    }
}
