using System;
using System.Threading.Tasks;
using BarIstasyon.Business.Features.CQRS.Commands.PricingCommands;
using BarIstasyon.Business.Features.CQRS.Queries.PricingQueries;
using BarIstasyon.Business.Features.CQRS.Handlers.PricingHandlers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using BarIstasyon.Business.Features.CQRS.Queries;

namespace BarIstasyon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly CreatePricingCommandHandler _createPricingCommandHandler;
        private readonly GetAllPricingQueryHandler _getAllPricingQueryHandler;
        private readonly UpdatePricingCommandHandler _updatePricingCommandHandler;
        private readonly RemovePricingCommandHandler _removePricingCommandHandler;
        private readonly GetPricingByIdQueryHandler _getPricingByIdQueryHandler;

        public PricingsController(
            CreatePricingCommandHandler createPricingCommandHandler,
            GetAllPricingQueryHandler getAllPricingQueryHandler,
            UpdatePricingCommandHandler updatePricingCommandHandler,
            RemovePricingCommandHandler removePricingCommandHandler,
            GetPricingByIdQueryHandler getPricingByIdQueryHandler)
        {
            _createPricingCommandHandler = createPricingCommandHandler;
            _getAllPricingQueryHandler = getAllPricingQueryHandler;
            _updatePricingCommandHandler = updatePricingCommandHandler;
            _removePricingCommandHandler = removePricingCommandHandler;
            _getPricingByIdQueryHandler = getPricingByIdQueryHandler;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePricing(string id, [FromBody] UpdatePricingCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                command.PricingID = objectId;
                await _updatePricingCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing([FromBody] CreatePricingCommand command)
        {
            if (command == null)
                return BadRequest("Geçersiz veri.");

            try
            {
                await _createPricingCommandHandler.Handle(command);
                return Ok("Hakkımda bilgisi eklendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPricings()
        {
            try
            {
                var result = await _getAllPricingQueryHandler.Handle(new GetAllPricingQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        // ✅ Silme endpoint'i
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePricing(string id)
        {
            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                    return BadRequest("Geçersiz ID formatı.");

                var command = new RemovePricingCommand(objectId);
                await _removePricingCommandHandler.Handle(command);

                return Ok("Hakkımda bilgisi başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricingById(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Geçersiz ID formatı.");
            }

            var result = await _getPricingByIdQueryHandler.Handle(new GetPricingByIdQuery(objectId));
            if (result == null)
            {
                return NotFound("Kayıt bulunamadı.");
            }

            return Ok(result);
        }
    }
}
