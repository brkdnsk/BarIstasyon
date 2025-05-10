using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.FooterAddressCommands;

using BarIstasyon.Business.Features.CQRS.Handlers.FooterAddressHandlers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries;
using BarIstasyon.Business.Features.CQRS.Queries.FooterAddressQueries;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddresssController : ControllerBase
    {
        private readonly CreateFooterAddressCommandHandler _createFooterAddressCommandHandler;
        private readonly GetAllFooterAddressQueryHandler _getAllFooterAddressQueryHandler;
        private readonly UpdateFooterAddressCommandHandler _updateFooterAddressCommandHandler;
        private readonly RemoveFooterAddressCommandHandler _removeFooterAddressCommandHandler;
        private readonly GetFooterAddressByIdQueryHandler _getFooterAddressByIdQueryHandler;

        public FooterAddresssController(
            CreateFooterAddressCommandHandler createFooterAddressCommandHandler,
            GetAllFooterAddressQueryHandler getAllFooterAddressQueryHandler,
            UpdateFooterAddressCommandHandler updateFooterAddressCommandHandler,
            RemoveFooterAddressCommandHandler removeFooterAddressCommandHandler,
            GetFooterAddressByIdQueryHandler getFooterAddressByIdQueryHandler)
        {
            _createFooterAddressCommandHandler = createFooterAddressCommandHandler;
            _getAllFooterAddressQueryHandler = getAllFooterAddressQueryHandler;
            _updateFooterAddressCommandHandler = updateFooterAddressCommandHandler;
            _removeFooterAddressCommandHandler = removeFooterAddressCommandHandler;
            _getFooterAddressByIdQueryHandler = getFooterAddressByIdQueryHandler;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFooterAddress(string id, [FromBody] UpdateFooterAddressCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                command.FooterAddressId = objectId;
                await _updateFooterAddressCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress([FromBody] CreateFooterAddressCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                await _createFooterAddressCommandHandler.Handle(command);
                return Ok("Hakkımda bilgisi eklendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFooterAddresss()
        {
            try
            {
                var result = await _getAllFooterAddressQueryHandler.Handle(new GetAllFooterAddressQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        // ✅ Silme endpoint'i
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFooterAddress(string id)
        {
            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                var command = new RemoveFooterAddressCommand(objectId);
                await _removeFooterAddressCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddressById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Geçersiz ID formatı.");
            }

            var result = await _getFooterAddressByIdQueryHandler.Handle(new GetFooterAddressByIdQuery(objectId));
            if (result == null)
            {
                return NotFound("Kayıt bulunamadı.");
            }

            return Ok(result);
        }
    }
}
