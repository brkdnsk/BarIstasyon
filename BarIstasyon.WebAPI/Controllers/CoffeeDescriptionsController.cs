using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.CoffeeDescriptionCommands;
using BarIstasyon.Business.Features.CQRS.Queries.CoffeeDescriptionQueries;
using BarIstasyon.Business.Features.CQRS.Handlers.CoffeeDescriptionHandlers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries.CategoryQueries;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeDescriptionsController : ControllerBase
    {
        private readonly CreateCoffeeDescriptionCommandHandler _createCoffeeDescriptionCommandHandler;
        private readonly GetAllCoffeeDescriptionQueryHandler _getAllCoffeeDescriptionQueryHandler;
        private readonly UpdateCoffeeDescriptionCommandHandler _updateCoffeeDescriptionCommandHandler;
        private readonly RemoveCoffeeDescriptionCommandHandler _removeCoffeeDescriptionCommandHandler;
        private readonly GetCoffeeDescriptionByIdQueryHandler _getCoffeeDescriptionByIdQueryHandler;

        public CoffeeDescriptionsController(
            CreateCoffeeDescriptionCommandHandler createCoffeeDescriptionCommandHandler,
            GetAllCoffeeDescriptionQueryHandler getAllCoffeeDescriptionQueryHandler,
            UpdateCoffeeDescriptionCommandHandler updateCoffeeDescriptionCommandHandler,
            RemoveCoffeeDescriptionCommandHandler removeCoffeeDescriptionCommandHandler,
            GetCoffeeDescriptionByIdQueryHandler getCoffeeDescriptionByIdQueryHandler)
        {
            _createCoffeeDescriptionCommandHandler = createCoffeeDescriptionCommandHandler;
            _getAllCoffeeDescriptionQueryHandler = getAllCoffeeDescriptionQueryHandler;
            _updateCoffeeDescriptionCommandHandler = updateCoffeeDescriptionCommandHandler;
            _removeCoffeeDescriptionCommandHandler = removeCoffeeDescriptionCommandHandler;
            _getCoffeeDescriptionByIdQueryHandler = getCoffeeDescriptionByIdQueryHandler;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoffeeDescription(string id, [FromBody] UpdateCoffeeDescriptionCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                command.CoffeeDescriptionID = objectId;
                await _updateCoffeeDescriptionCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoffeeDescription([FromBody] CreateCoffeeDescriptionCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                await _createCoffeeDescriptionCommandHandler.Handle(command);
                return Ok("Hakkımda bilgisi eklendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoffeeDescriptions()
        {
            try
            {
                var result = await _getAllCoffeeDescriptionQueryHandler.Handle(new GetAllCoffeeDescriptionQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        // ✅ Silme endpoint'i
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoffeeDescription(string id)
        {
            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                var command = new RemoveCoffeeDescriptionCommand(objectId);
                await _removeCoffeeDescriptionCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoffeeDescriptionById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Geçersiz ID formatı.");
            }

            var result = await _getCoffeeDescriptionByIdQueryHandler.Handle(new GetCoffeeDescriptionByIdQuery(objectId));
            if (result == null)
            {
                return NotFound("Kayıt bulunamadı.");
            }

            return Ok(result);
        }
    }
}
